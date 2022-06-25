/*
- findIndex(); bulduğu şartın index numarasını bize döndürür.
arrayın bulunan objesinin index numarasını döndürür.
Gördüğü ilk index numarasını döndürür, yoksa -1 değerini döndürür
*/
import people from './data.js';
  
console.log(
    'Yaşı 24 e eşit olan personun index numarası: ',
    people.findIndex(item => item.age == 24) // Çıktı -> 8
)
