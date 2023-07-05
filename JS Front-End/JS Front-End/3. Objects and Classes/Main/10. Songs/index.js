function createSong(array) {
  class Song {
    constructor(typeList, name, time) {
      this.typeList = typeList;
      this.name = name;
      this.time = time;
    }
  }
  let arrayOfSongs = [];
  for (i = 1; i <= array[0]; i++) {
    let [typeList, name, time] = array[i].split("_");
    arrayOfSongs.push(new Song(typeList, name, time));
  }
  if (array[array.length - 1] == "all") {
    arrayOfSongs.forEach((element) => {
      console.log(element.name);
    });
  } else {
    const type = array[array.length - 1];
    arrayOfSongs
      .filter((element) => element.typeList == type)
      .forEach((element) => console.log(element.name));
  }
}

createSong([2, "like_Replay_3:15", "ban_Photoshop_3:48", "all"]);
