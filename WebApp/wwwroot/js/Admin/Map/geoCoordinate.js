var id, target, options;

options = {
  enableHighAccuracy: true,
  timeout: 15000,
  maximumAge: 0
};

var vm = new Vue({
      el: '#geo-coordinate-page',
      data: {
        userCurrentLocation: {
          lat: null,
          lng: null
        }
      },
      created: function () {
        this.watchLocation();
      },
      methods: {
        getLocation: function() {
          
          if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(this.setPosition, this.error, options);
          }
          
        },
        watchLocation: function () {

          if (navigator.geolocation) {
            id = navigator.geolocation.watchPosition(this.setPosition, this.error, options);
          }

        },
        setPosition: function(position) {
          this.userCurrentLocation.lng = position.coords.longitude;
          this.userCurrentLocation.lat = position.coords.latitude;
        },
        error: function(err) {
          console.warn('ERROR(' + err.code + '): ' + err.message);
        },
        startTimer: function() {
          this.interval = setInterval(this.countDown, 1000);
          this.timerStarted = true;
        },
      },
      watch: {
        userCurrentLocation : {
          handler: function () {
            
        },
        deep: true //Need for tracking object child changes
      }

    },
    computed: {
  
    }
});