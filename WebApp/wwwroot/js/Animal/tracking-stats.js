var id, target, options;

options = {
  enableHighAccuracy: true,
  timeout: 15000,
  maximumAge: 0
};

var vm = new Vue({
      el: '#tracking-stats-page',
      data: {
        startLocation: {
          lat: 59.4299856,
          lng: 24.7699037
        },
        userCurrentLocation: {
          lat: 59.43001,
          lng: 24.769921
        },
        animalLocation: {
          lat: 59.4516626,
          lng: 24.7174568
        },
        distance: 0,
        meanDistance: 0,
        distanceSum: 0,
        animalList: [],
        timer: 60,
        message2: "",
        counter: false,
        interval: null
      },
      created: function () {
        //this.getLocation();
      },
      methods: {
        getLocation: function() {
          
          if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(this.setStartPosition, this.error, options);
          }
          
        },
        watchLocation: function () {

          if (navigator.geolocation) {
            id = navigator.geolocation.watchPosition(this.setPosition, this.error, options);
          }

        },
        setStartPosition: function(position) {
          this.startLocation.lng = position.coords.longitude;
          this.startLocation.lat = position.coords.latitude;
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
        },
        runForTime: function () {
          this.startTimer();
          this.watchLocation();
        },
        stopLocationWatch: function () {
          navigator.geolocation.clearWatch(id);
        },
        startTimer: function() {
          this.interval = setInterval(this.countDown, 1000);
          this.timerStarted = true;
        },
        countDown: function() {
          var n = this.timer
          if (!this.counter) {
            this.counter = true;
          } else if (n > 0) {
            n = n - 1
            this.timer = n
            this.message2 = "You have " + n + "seconds left."
          } else {
            this.stopLocationWatch();
            this.counter = false
            this.message2 = "Your time is up!"
          }
        }
      },
      watch: {
        userCurrentLocation : {
          handler: function () {
            
            this.distance = this.getDistance(this.userCurrentLocation, this.startLocation);

              this.animalList.push({
                distance: this.distance
              });
              
              this.distanceSum += this.distance;
              this.meanDistance = this.distanceSum  / this.animalList.length;

            this.startLocation.lng = this.userCurrentLocation.lng;
            this.startLocation.lat = this.userCurrentLocation.lat;
        },
        deep: true //Need for tracking object child changes
      }

    },
    computed: {
  
  }
});