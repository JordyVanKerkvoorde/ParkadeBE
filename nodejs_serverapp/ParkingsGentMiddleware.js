// 'https://datatank.stad.gent/4/mobiliteit/bezettingparkingsrealtime.json'
console.log("applicatie succesvol opgestart: Parkeergarages")
const fetch = require("node-fetch");
const sql = require('mssql');

function fetchRequest(url) {
	return fetch(url)
		.then(body => body.json()); //retourneert promise object met response
}

function getData(){
  fetchRequest('https://datatank.stad.gent/4/mobiliteit/bezettingparkingsrealtime.json')
    .then(result => {
        let parkInit = new ParkingInitializer();
        parkInit.addParkings(result);
        console.log(parkInit.parkings);
        parkInit.parkings.forEach((parking) =>{
          databaseconn(parking);
        });
    })
    .catch(reject => {
        console.log(reject);
    })
}

class ParkingInitializer{
  constructor(){
    this._parkData = new Array();
  }

  addParkings(data){
    //filteren van de api data op nuttige data
    this._parkData = data.map(p => new Parking(
      p.id, //mogelijks niet nodig
      p.description, 
      p.latitude, 
      p.longitude, 
      p.parkingStatus.availableCapacity, 
      p.parkingStatus.totalCapacity,
      p.parkingStatus.lastModifiedDate
      ));
  }
  get parkings(){
    return this._parkData;
  }
}

//Parking object met benodigde data
class Parking{
  constructor(id, name, latitude, longtitude, availablecap, totalcap){
    this._id = id;
    this._name = name;
    this._latitude = latitude;
    this._longtitude = longtitude;
    this._available = availablecap;
    this._maxcap = totalcap;
    this._type = "car";
  }
}

async function databaseconn(parking){
  var name = parking._name;
  var type = parking._type;
  var latitude = "" + parking._latitude;
  var longtitude = "" + parking._longtitude;
  var maxcap = parseInt(parking._maxcap);
  var availablecap = parseInt(parking._available);

   try{
     //connection string afgeschermd, database draait op externe server
       let pool = await sql.connect('Server=xxx.xxx.xxx.xxx,51433;Database=Parkings;User Id=xxxxx;Password=xxxxxxx;');
         await pool.request().query(`
          if not exists (select 1 from [Parking] where [Name] = '${name}')
          begin
          insert into Parking ([Name], [Type], [Latitude], [Longtitude], [MaxCap]) 
          values ('${name}', '${type}', '${latitude}', '${longtitude}', ${maxcap})
          end
        `);
        await pool.request().query(`
        insert into [Entry] ([TimeDay], [Available], [ParkingId]) 
        values (CURRENT_TIMESTAMP, ${availablecap}, (select Id from Parking where Name = '${name}'))
        `);
      pool.close();
  } catch (err){
    console.log(err);
  }
}

setInterval(() =>{
  getData();
}, 300000); //om de 5 minuten data ophalen
