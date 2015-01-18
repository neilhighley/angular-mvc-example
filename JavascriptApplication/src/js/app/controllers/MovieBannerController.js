

/*
{"Title":"Star",
"Year":"2001",
"Rated":"N/A",
"Released":"01 Jun 2001",
"Runtime":"7 min",
"Genre":"Action, Short, Comedy",
"Director":"Guy Ritchie",
"Writer":"Joe Sweet (screenplay), Guy Ritchie",
"Actors":"Clive Owen, Michael Beattie, Toru Tanaka Jr., DTeflon",
"Plot":"The Driver now carries an arrogant rock star who is visiting a major city (not Pittsburgh as earlier believed). Played by Madonna, this title character wants to get away from her bodyguards...",
"Language":"English",
"Country":"USA",
"Awards":"1 win.",
"Poster":"http://ia.media-imdb.com/images/M/MV5BMTY0NTY2NTUwNV5BMl5BanBnXkFtZTYwNzQxMzg5._V1_SX300.jpg","Metascore":"N/A","imdbRating":"7.8","imdbVotes":"5,617","imdbID":"tt0286151","Type":"movie","tomatoMeter":"83","tomatoImage":"N/A","tomatoRating":"N/A","tomatoReviews":"N/A","tomatoFresh":"N/A","tomatoRotten":"N/A","tomatoConsensus":"N/A","tomatoUserMeter":"83","tomatoUserRating":"4","tomatoUserReviews":"231","DVD":"N/A","BoxOffice":"N/A","Production":"N/A","Website":"N/A","Response":"True"}
*/


var moviesConfig = {
    interval: 10000,
    moviesLoaded: 0,
    url: "http://www.omdbapi.com/?t=##TITLE##&r=json&tomatoes=true",
    movies:[{ Title: 'aliens',Image:"" },
            { Title: '12 angry men', Image: "" },
            { Title: 'the terminator', Image: "" },
            { Title: 'kill a mockingbird', Image: "" },
            { Title: 'sharknado', Image: "" },
            { Title: 'inherit the wind', Image: "" },
            { Title: 'fifth', Image: "" },
            { Title: 'hackers', Image: "" },
            { Title: 'true romance', Image: "" },
            { Title: 'give', Image: "" }]
};

taskApp.controller("MovieBannerCtrl", function($scope,$http,MovieBannerService) {
    $scope.conf = moviesConfig;
    $scope.conf.movies = MovieBannerService.GetMovies($scope.conf.movies, $scope.conf.url);
});
