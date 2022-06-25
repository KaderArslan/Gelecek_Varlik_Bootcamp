/*
- find(); array içerisinde istediğimiz belirlediğimiz kriterlere göre bir datayı bulmayı sağlar. Şartı sağlayan ilk datayı geri döndürür.
*/
import people from './data.js';

//yaşı 30 dan büyük olanları verme
console.log(
    'Yaşı 30 dan büyük olan person bilgisi: ',
    people.find(item => item.age > 30)
)
/* Çıktı
{
    name: 'akif',
    surname: 'özoğlu',
    age: '32',
    location: 'istanbul',
    gender: 'man',
    score: 17,
    workingDays: 17,
    books: 9
}
*/
  
  


  

