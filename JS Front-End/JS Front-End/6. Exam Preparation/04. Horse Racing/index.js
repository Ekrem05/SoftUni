function solve(array) {
  const placing = array[0];
  let horseTrack = placing.split("|");
  const commands = array.splice(1);
  const trackActions = {
    Swap: (array, firstitem, secondItem) => {
      let temp = array[array.indexOf(secondItem)];
      array[array.indexOf(secondItem)] = firstitem;
      array[array.indexOf(firstitem)] = temp;
      return array;
    },
    Retake: (array, overtaking, overtaken) => {
      array = trackActions.Swap(array, overtaking, overtaken);
      console.log(`${overtaking} retakes ${overtaken}.`);
      return array;
    },
    Trouble: (array, horseName) => {
      const index = array.indexOf(horseName);

      if (index != 0) {
        array = trackActions.Swap(array, array[index - 1], horseName);
        console.log(`Trouble for ${horseName} - drops one position.`);
      }
      return array;
    },
    Rage: (array, horseName) => {
      const index = array.indexOf(horseName);
      const second = array.length - 2;
      if (index == second) {
        array = trackActions.Swap(array, horseName, array[array.length - 1]);
      } else if (index < second) {
        const horseBef = index;
        const horseAf = index + 1;

        array = trackActions.Swap(array, horseName, array[index + 2]);
        array = trackActions.Swap(array, array[horseBef], array[horseAf]);
      }
      console.log(`${horseName} rages 2 positions ahead.`);
      return array;
    },
    Miracle: (array) => {
      const last = array[0];
      const first = array[array.length - 1];
      const stop = array.length - 1;
      for (i = 0; i < stop; i++) {
        array[i] = array[i + 1];
      }
      array[stop] = last;
      console.log(`What a miracle - ${last} becomes first.`);
      return array;
    },
  };
  let finish = false;
  commands.forEach((element) => {
    const actions = element.split(" ");
    const action = actions[0];
    if (!finish) {
      switch (action) {
        case "Retake":
          const first = actions[1];
          const second = actions[2];
          if (first < second) {
            horseTrack = trackActions.Retake(horseTrack, first, second);
          }
          break;
        case "Rage":
          const horseName = actions[1];
          horseTrack = trackActions.Rage(horseTrack, horseName);
          break;
        case "Trouble":
          const horseName2 = actions[1];
          horseTrack = trackActions.Trouble(horseTrack, horseName2);
          break;
        case "Miracle":
          horseTrack = trackActions.Miracle(horseTrack);
          break;
        case "Finish":
          console.log(horseTrack.join("->"));
          const firstPlace = horseTrack.length - 1;
          console.log(`The winner is: ${horseTrack[firstPlace]}`);
          finish = true;
          break;
      }
    }
  });
}

solve(["Onyx|Domino|Sugar|Fiona", "Finish"]);
