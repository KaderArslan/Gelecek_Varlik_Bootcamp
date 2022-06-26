# Kader Arslan Homework 1
```
1. Reduce ile isimlerin baş harfine göre gruplandırma
2. Yaşadıkları şehirlere göre gruplandırma
```

## Homework Description

```
Amaç; Reduce metodunu anlamak ve kullanabilmek. 
* JavaScriptte kullanılan diğer fonksiyonlarla da örnekler yaptım ilerleyen süreçlerde eklemeye devam edeceğim.
```

#### Ödev 1; Reduce ile isimlerin baş harfine göre gruplandırma : [homeworkReduce](https://github.com/GelecekVarlik-FullStack-Bootcamp/odev-5-react-1-KaderArslan/blob/main/homeworkReduce.js)

```
console.log (
  'Reduce ile isimlerin baş harfine göre gruplandırma',
  people.reduce((store, word) => {
    const letter = word.name.charAt(0) // name'in bas harfini alır
    const keyStore = (
      store[letter] ||     // Nesne var mi
      (store[letter] = []) // eger yoksa bos bir dizi olarak doner
    ); 
    keyStore.push(word)

    return store
  }, {})
)
```

#### Çıktı;

```
Reduce ile isimlerin baş harfine göre gruplandırma {
  h: [
    {
      name: 'hakan',
      surname: 'özoğlu',
      age: '30',
      location: 'istanbul',
      gender: 'man',
      score: 10,
      workingDays: 90,
      books: 1
    }
  ],
  a: [
    {
      name: 'akif',
      surname: 'özoğlu',
      age: '32',
      location: 'istanbul',
      gender: 'man',
      score: 17,
      workingDays: 17,
      books: 9
    },
    {
      name: 'alp',
      surname: 'öztürk',
      age: '28',
      location: 'aydın',
      gender: 'man',
      score: 28,
      workingDays: 64,
      books: 178
    }
  ],
  b: [
    {
      name: 'beyza',
      surname: 'özoğlu',
      age: '16',
      location: 'trabzon',
      gender: 'woman',
      score: 28,
      workingDays: 64,
      books: 178
    },
    {
      name: 'büşra',
      surname: 'ece',
      age: '23',
      location: 'kars',
      gender: 'woman',
      score: 28,
      workingDays: 64,
      books: 178
    }
  ],
  s: [
    {
      name: 'serdar',
      surname: 'çakır',
      age: '22',
      location: 'istanbul',
      gender: 'man',
      score: 28,
      workingDays: 64,
      books: 178
    }
  ],
  r: [
    {
      name: 'rümeysa',
      surname: 'türkan',
      age: '22',
      location: 'istanbul',
      gender: 'man',
      score: 28,
      workingDays: 64,
      books: 178
    }
  ],
  m: [
    {
      name: 'mehmet ali',
      surname: 'tunay',
      age: '30',
      location: 'istanbul',
      gender: 'man',
      score: 28,
      workingDays: 64,
      books: 178
    }
  ],
  f: [
    {
      name: 'furkan',
      surname: 'atsan',
      age: '23',
      location: 'ankara',
      gender: 'man',
      score: 28,
      workingDays: 64,
      books: 178
    }
  ],
  k: [
    {
      name: 'kader',
      surname: 'arslan',
      age: '24',
      location: 'adana',
      gender: 'woman',
      score: 28,
      workingDays: 64,
      books: 178
    }
  ],
  u: [
    {
      name: 'uğurcan',
      surname: 'uçar',
      age: '24',
      location: 'trabzon',
      gender: 'man',
      score: 28,
      workingDays: 64,
      books: 178
    }
  ],
  e: [
    {
      name: 'esra',
      surname: 'rengiz',
      age: '24',
      location: 'adana',
      gender: 'woman',
      score: 28,
      workingDays: 64,
      books: 178
    }
  ],
  y: [
    {
      name: 'yasemin',
      surname: 'arslan',
      age: '24',
      location: 'bitlis',
      gender: 'man',
      score: 28,
      workingDays: 64,
      books: 178
    }
  ]
}
```

#### Ödev 2; Yaşadıkları şehirlere göre gruplandırma : [homeworkReduce](https://github.com/GelecekVarlik-FullStack-Bootcamp/odev-5-react-1-KaderArslan/blob/main/homeworkReduce.js)

```
console.log (
  'Yaşadıkları şehirlere göre gruplandırma',
  people.reduce((item, person) => {
    const city = person.location // il ismini alır
    const keyItem = (
      item[city] ||     // Nesne var mi
      (item[city] = []) // eger yoksa bos bir dizi olarak doner
    ); 
    keyItem.push(person)
  
    return item
  }, {})
)
```

#### Çıktı;

```
Yaşadıkları şehirlere göre gruplandırma {
  istanbul: [
    {
      name: 'hakan',
      surname: 'özoğlu',
      age: '30',
      location: 'istanbul',
      gender: 'man',
      score: 10,
      workingDays: 90,
      books: 1
    },
    {
      name: 'akif',
      surname: 'özoğlu',
      age: '32',
      location: 'istanbul',
      gender: 'man',
      score: 17,
      workingDays: 17,
      books: 9
    },
    {
      name: 'serdar',
      surname: 'çakır',
      age: '22',
      location: 'istanbul',
      gender: 'man',
      score: 28,
      workingDays: 64,
      books: 178
    },
    {
      name: 'rümeysa',
      surname: 'türkan',
      age: '22',
      location: 'istanbul',
      gender: 'man',
      score: 28,
      workingDays: 64,
      books: 178
    },
    {
      name: 'mehmet ali',
      surname: 'tunay',
      age: '30',
      location: 'istanbul',
      gender: 'man',
      score: 28,
      workingDays: 64,
      books: 178
    }
  ],
  trabzon: [
    {
      name: 'beyza',
      surname: 'özoğlu',
      age: '16',
      location: 'trabzon',
      gender: 'woman',
      score: 28,
      workingDays: 64,
      books: 178
    },
    {
      name: 'uğurcan',
      surname: 'uçar',
      age: '24',
      location: 'trabzon',
      gender: 'man',
      score: 28,
      workingDays: 64,
      books: 178
    }
  ],
  'aydın': [
    {
      name: 'alp',
      surname: 'öztürk',
      age: '28',
      location: 'aydın',
      gender: 'man',
      score: 28,
      workingDays: 64,
      books: 178
    }
  ],
  ankara: [
    {
      name: 'furkan',
      surname: 'atsan',
      age: '23',
      location: 'ankara',
      gender: 'man',
      score: 28,
      workingDays: 64,
      books: 178
    }
  ],
  adana: [
    {
      name: 'kader',
      surname: 'arslan',
      age: '24',
      location: 'adana',
      gender: 'woman',
      score: 28,
      workingDays: 64,
      books: 178
    },
    {
      name: 'esra',
      surname: 'rengiz',
      age: '24',
      location: 'adana',
      gender: 'woman',
      score: 28,
      workingDays: 64,
      books: 178
    }
  ],
  kars: [
    {
      name: 'büşra',
      surname: 'ece',
      age: '23',
      location: 'kars',
      gender: 'woman',
      score: 28,
      workingDays: 64,
      books: 178
    }
  ],
  bitlis: [
    {
      name: 'yasemin',
      surname: 'arslan',
      age: '24',
      location: 'bitlis',
      gender: 'man',
      score: 28,
      workingDays: 64,
      books: 178
    }
  ]
}
```

#### Kullanılan Data: [data](https://github.com/GelecekVarlik-FullStack-Bootcamp/odev-5-react-1-KaderArslan/blob/main/data.js)

```
const person1 = {
    name: 'hakan',
    surname: 'özoğlu',
    age: '30',
    location: 'istanbul',
    gender: 'man',
    score: 10,
    workingDays: 90,
    books: 1,
  }
  const person2 = {
    name: 'akif',
    surname: 'özoğlu',
    age: '32',
    location: 'istanbul',
    gender: 'man',
    score: 17,
    workingDays: 17,
    books: 9,
  }
  const person3 = {
    name: 'beyza',
    surname: 'özoğlu',
    age: '16',
    location: 'trabzon',
    gender: 'woman',
    score: 28,
    workingDays: 64,
    books: 178,
  }
  const person4 = {
    name: 'alp',
    surname: 'öztürk',
    age: '28',
    location: 'aydın',
    gender: 'man',
    score: 28,
    workingDays: 64,
    books: 178,
  }
  const person5 = {
    name: 'serdar',
    surname: 'çakır',
    age: '22',
    location: 'istanbul',
    gender: 'man',
    score: 28,
    workingDays: 64,
    books: 178,
  }
  const person6 = {
    name: 'rümeysa',
    surname: 'türkan',
    age: '22',
    location: 'istanbul',
    gender: 'man',
    score: 28,
    workingDays: 64,
    books: 178,
  }
  const person7 = {
    name: 'mehmet ali',
    surname: 'tunay',
    age: '30',
    location: 'istanbul',
    gender: 'man',
    score: 28,
    workingDays: 64,
    books: 178,
  }
  const person8 = {
    name: 'furkan',
    surname: 'atsan',
    age: '23',
    location: 'ankara',
    gender: 'man',
    score: 28,
    workingDays: 64,
    books: 178,
  }
  const person9 = {
    name: 'kader',
    surname: 'arslan',
    age: '24',
    location: 'adana',
    gender: 'woman',
    score: 28,
    workingDays: 64,
    books: 178,
  }
  const person10 = {
    name: 'uğurcan',
    surname: 'uçar',
    age: '24',
    location: 'trabzon',
    gender: 'man',
    score: 28,
    workingDays: 64,
    books: 178,
  }
  const person11 = {
    name: 'esra',
    surname: 'rengiz',
    age: '24',
    location: 'adana',
    gender: 'woman',
    score: 28,
    workingDays: 64,
    books: 178,
  }
  const person12 = {
    name: 'büşra',
    surname: 'ece',
    age: '23',
    location: 'kars',
    gender: 'woman',
    score: 28,
    workingDays: 64,
    books: 178,
  }
  const person13 = {
    name: 'yasemin',
    surname: 'arslan',
    age: '24',
    location: 'bitlis',
    gender: 'man',
    score: 28,
    workingDays: 64,
    books: 178,
  }
  
  const people = [person1, person2, person3, person4, person5, person6, person7, person8, person9, person10,person11,person12,person13]

  export default people;
```

## Author
```Kader Arslan```

<!-- spread
 higher order
entries
incledes
slides
sort
sum
unshift
shift
an
flat
startsWith
edWith-->
