var vm = new Vue({
  el: '#animals-page',
  data: {
    searchInput: '',
    animalList: []
  },
  created: function () {
    this.animalList = JSON.parse(document.getElementById("animalList").textContent);
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
    filteredAnimals: function () {
      var filteredList = this.getByKeyword(this.animalList, this.searchInput);
      return filteredList;
    }
  }
});