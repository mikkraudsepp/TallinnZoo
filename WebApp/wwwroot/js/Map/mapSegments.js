var vm = new Vue({
  el: '#map-segments-page',
  data: {
    searchInput: '',
    mapSegmenetsList: []
  },
  created: function () {
    this.mapSegmenetsList = JSON.parse(document.getElementById("map-segments-list").textContent);
  },
  methods: {
    getByKeyword: function (list, keyword) {
      keyword = keyword.trim();
      keyword = keyword.toLowerCase();

      if (!keyword.length) return list;
      return list.filter(function (item) {
        return item.Name.toLowerCase().indexOf(keyword) !== -1;
      });
    },
  },
  watch: {

  },
  computed: {
    filteredMapSegments: function () {
      var filteredList = this.getByKeyword(this.mapSegmenetsList, this.searchInput);
      return filteredList;
    }
  }
});