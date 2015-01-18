taskApp.factory("MovieBannerService", function ($http,$q) {
    var url = "";
    return {
        GetMovies: function (titlesArray, urlToUse) {
            var retMovies = [];
            if (urlToUse != undefined) {
                url = urlToUse;
            };
            for (var i = 0; i < titlesArray.length; i++) {
                $http.get(url.replace("##TITLE##", titlesArray[i].Title)).
                  then(function (resp) {
                      retMovies.push({
                          Title: resp.data.Title,
                          Image: resp.data.Poster
                      });
                  },
                  function (resp) {
                      return $q.reject(resp);
                  });
            }
            return retMovies;
        },
        SetURL:function(u) {
            url = u;
        }
    }
    
})