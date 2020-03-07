// https://data.stad.gent/api/records/1.0/search/?dataset=real-time-bezettingen-fietsenstallingen-gent
console.log("applicatie succesvol opgestart: Fietsenstallingen Gent")
const fetch = require("node-fetch");
function fetchRequest(url) {
	return fetch(url)
		.then(body => body.json()); //retourneert promise object met response
}

function getData(){
  fetchRequest('https://data.stad.gent/api/records/1.0/search/?dataset=real-time-bezettingen-fietsenstallingen-gent')
    .then(result => {
        let parkInit = new ParkingInitializer();
        parkInit.addParkings(result);
        //afprinten van data later veranderen door .NET API POST
        console.log(parkInit.parkings);
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
    this._parkData = data.records.map(p => new Parking(
      p.fields.id, //mogelijks niet nodig
      p.fields.facilityname, 
      p.fields.freeplaces, 
      p.fields.totalplaces));
  }
  get parkings(){
    return this._parkData;
  }
}

//Parking object met benodigde data
class Parking{
  constructor(id, name, availablecap, totalcap){
    this._id = id;
    this._name = name;
    this._availablecap = availablecap;
    this._totalcap = totalcap;
  }
}

setInterval(() =>{
  getData();
}, 300000); //om de 5 minuten data ophalen
