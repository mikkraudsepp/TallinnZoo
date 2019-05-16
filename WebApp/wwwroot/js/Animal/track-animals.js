var id, target, options;

options = {
  enableHighAccuracy: true,
  timeout: 15000,
  maximumAge: 1000
};

var vm = new Vue({
  el: '#track-animals-page',
  data: {
    userCurrentLocation: {
      lat: 59.4518904,
      lng: 24.71695
    },
    animalLocation: {
      lat: 59.4516626,
      lng: 24.7174568
    },
    distance: '',
    animalList: [],
    elapsedTime: 0,
    calculationCycles: 0
  },
  created: function () {
    this.animalList = JSON.parse(document.getElementById("animal-list").textContent);
    //this.distance = this.getDistance(this.animalLocation, this.userCurrentLocation);
    this.getLocation();
    this.startWatchLocation();
    //this.distance = this.getDistance(this.animalLocation, this.userCurrentLocation);
  },
  methods: {
    getLocation: function () {

      if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(this.setPosition, this.error, options);
      }

    },
    startWatchLocation: function () {

      if (navigator.geolocation) {
        navigator.geolocation.watchPosition(this.setPosition, this.error, options);
      }

    },
    setPosition: function(position) {
      this.userCurrentLocation.lng = position.coords.longitude;
      this.userCurrentLocation.lat = position.coords.latitude;
    },
    getDistance: function(p1, p2) {
      //https://stackoverflow.com/a/1502821/4183424
      var R = 6378137; // Earth’s mean radius in meter
      var dLat = this.getRad(p2.lat - p1.lat);
      var dLong = this.getRad(p2.lng - p1.lng);
      var a = Math.sin(dLat / 2) * Math.sin(dLat / 2) +
          Math.cos(this.getRad(p1.lat)) * Math.cos(this.getRad(p2.lat)) *
          Math.sin(dLong / 2) * Math.sin(dLong / 2);
      var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
      var d = R * c;
      return d; // returns the distance in meter
    },
    getLocalDistance: function() {
      this.distance = this.getDistance(this.animalLocation, this.userCurrentLocation);
    },
    getGoogleDistance: function() {
      this.distance = google.maps.geometry.spherical.computeDistanceBetween (new google.maps.LatLng(this.userCurrentLocation.lat, this.userCurrentLocation.lng), new google.maps.LatLng(this.animalLocation.lat, this.animalLocation.lng));
    },
    getRad: function(x) {
      return x * Math.PI / 180;
    },
    error: function(err) {
      console.warn('ERROR(' + err.code + '): ' + err.message);
    }
  },
  watch: {
    userCurrentLocation : {
      handler: function () {

        var start = new Date();
        this.calculationCycles = 0;
        
        //for(var j=0; j < 20000; j++) {
          for(var i=0; i < this.animalList.length; i++) {
            
            var curDistanceFromPoint = [];

            for(var k=0; k < this.animalList[i].MapSegment.GeoCoordinates.length; k++) {
              
              var animalLocation = {
                lat: this.animalList[i].MapSegment.GeoCoordinates[k].Latitude,
                lng: this.animalList[i].MapSegment.GeoCoordinates[k].Longitude
              };

              curDistanceFromPoint.push(this.getDistance(this.userCurrentLocation, animalLocation).toFixed(3));
            }
            console.log(curDistanceFromPoint);

            this.animalList[i].DistanceFromUser = Math.min.apply( Math, curDistanceFromPoint );

            //this.animalList[i].DistanceFromUser = google.maps.geometry.spherical.computeDistanceBetween (new google.maps.LatLng(this.userCurrentLocation.lat, this.userCurrentLocation.lng), new google.maps.LatLng(animalLocation.lat, animalLocation.lng));
            //this.calculationCycles += 1;
          }
        //}

        this.elapsedTime = new Date() - start;

        this.animalList.sort((a, b) => parseFloat(a.DistanceFromUser) - parseFloat(b.DistanceFromUser));
        //this.distance = this.getDistance(this.animalLocation, this.userCurrentLocation);
      },
      deep: true //Need for tracking object child changes
    }

  },
  computed: {

  }
});