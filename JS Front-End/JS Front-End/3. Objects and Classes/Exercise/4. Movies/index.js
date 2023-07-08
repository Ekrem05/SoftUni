function solve(array) {
  let movies = [];
  array.forEach((element) => {
    if (element.includes("addMovie")) {
      const movieName = element.split("addMovie ")[1];

      movies.push({
        name: movieName,
        director: null,
        date: null,
      });
    } else if (element.includes("directedBy")) {
      const [movieName, director] = element.split(" directedBy ");
      const movieWithDirector = movies.find((array) => array.name == movieName);
      if (movieWithDirector) {
        movieWithDirector.director = director;
      }
    } else if (element.includes("onDate")) {
      const [movieName, date] = element.split(" onDate ");
      const movieWithDirector = movies.find((array) => array.name == movieName);
      if (movieWithDirector) {
        movieWithDirector.date = date;
      }
    }
  });
  let i = 0;
  movies
    .filter((m) => m.name && m.director && m.date)
    .forEach((m) => console.log(JSON.stringify(m)));
  // movies
  //   .filter((m) => {
  //     m.name && m.director && m.date;
  //   })
  //   .forEach((m) => console.log(JSON.stringify(m)));
}

solve([
  "addMovie Fast and Furious",
  "addMovie test",
  "addMovie Godfather",
  "Inception directedBy Christopher Nolan",
  "Godfather directedBy Francis FordCoppola",
  "Godfather onDate 29.07.2018",
  "Fast and Furious onDate 30.07.2018",
  "Batman onDate 01.08.2018",
  "Fast and Furious directedBy Rob Cohen",
]);
