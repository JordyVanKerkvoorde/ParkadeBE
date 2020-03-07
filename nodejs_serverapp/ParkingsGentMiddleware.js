// 'https://datatank.stad.gent/4/mobiliteit/bezettingparkingsrealtime.json'
console.log("applicatie succesvol opgestart: Parkeergarages")
const fetch = require("node-fetch");
function fetchRequest(url) {
	return fetch(url)
		.then(body => body.json()); //retourneert promise object met response
}

function getData(){
  fetchRequest('https://datatank.stad.gent/4/mobiliteit/bezettingparkingsrealtime.json')
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
    this._parkData = data.map(p => new Parking(
      p.id, //mogelijks niet nodig
      p.description, 
      p.latitude, 
      p.longitude, 
      p.parkingStatus.availableCapacity, 
      p.parkingStatus.totalCapacity));
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
    this._availablecap = availablecap;
    this._totalcap = totalcap;
  }
}

setInterval(() =>{
  getData();
}, 300000); //om de 5 minuten data ophalen
