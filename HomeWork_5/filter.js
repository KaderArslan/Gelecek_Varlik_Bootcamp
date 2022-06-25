/*
- filter(); arrayi filtrelemek için kullanılır.
değişkene atar
*/

import people from './data.js';

console.log(
  'Yaşı 30 dan büyük olanlar: ',
  people.filter(item => {
    return item.age > 30;
  })
)

console.log('------------------------------------')

console.log(
  'Yaşı 23 dan büyük olanlar ve kadın olanlar: ',
  people.filter(item => {
      return item.age > 23 && item.gender == "woman";
  })
)

console.log('------------------------------------')

let filtered = [];
people.forEach(item => {
  // console.log("item", item);
  if (item.age > 30) {
    filtered.push(item);
  }
});
console.log("filtered foreach ile yaşı 30 dan büyük olanlar", filtered);