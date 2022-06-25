/*
- map(); benim arraydeki verileri istediğimiz formatta yeni bir array oluşturmak için kullanıyoruz.
*/
import people from './data.js';

// console.log('data: ',people.map(item => item))

console.log('------------------------------------')

console.log('score verileri: ',people.map(item => item.score))

console.log('------------------------------------')

console.log(
  'isim, soyisim ve il bilgileri: ',
  people.map(item => {
    return {
      isim: item.name,
      soyisim: item.surname,
      il: item.location
    };
  })
)

console.log('------------------------------------')

console.log(
  'isim soyisim [çalıştığı gün bilgisi]: ',
  people.map(item => {
    // return item.name + item.surname + item.workingDays;
    return item.name + item.surname + "[" + item.workingDays + "]" ;
  })
)

console.log('------------------------------------')

//${değişken ile}
console.log(
people.map(item => {
  return `${item.name} ${item.surname} => calistigi gun : [ ${item.workingDays} ]`;
})
)

console.log('------------------------------------')

console.log(
  'konumları',
  people.map(item => {
    return {
      lat: item.location
    };
  })
)

console.log('------------------------------------')

// map() bunu forEachle deniyoruz
let filtered = [];
people.forEach(item => {
  // console.log("item", item);
  filtered.push({
    name: item.name,
    surname: item.surname
  });
})
console.log("item forEach", filtered);

console.log('------------------------------------')

//map ile yaptık aynısını
console.log(
  'item map',
  people.map(item => {
    return {
      name: item.name,
      surname: item.surname
    };
  })
)

console.log('------------------------------------')

console.log(
  'willSaveData yeni düzende veriler',
  people.map(item => {
    return {
      name: item.name,
      email: item.surname,
      gender: item.gender,
      age: item.age,
      lat: item.location
    };
  })
)

console.log('------------------------------------')

console.log(
  'willSaveData yaşı 20 den küçük',
  people.filter(i => i.age <= 20)
  .map(item => {
    return {
      name: item.name,
      email: item.surname,
      gender: item.gender,
      age: item.age,
      lat: item.location
    };
  })
)
