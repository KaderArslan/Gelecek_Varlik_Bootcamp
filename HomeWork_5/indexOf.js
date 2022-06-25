/*
- indexOf(); Bilinen değerin kaçıncı indexte olduğunu söyler.
kriterlere uyan denk gelen objeyi aramayı sağlıyor
verinin kendisini sunarak indexisin ne olduğunu söylememize ve hangi indisten başlamamız gerektiğini belirtebileceğimiz bir fonksiyondur 
bu array içinde bir eleman arıyoruz. spesifik olarak elemanın kendisini belirteceğiz
*/

let people = [
  "Kader",
  "Arslan",
  "Yasemin",
  "Büşra",
  "Esra",
  "Ece",
  1,
  2,
  3,
  4,
  5
];

console.log(people.indexOf("Kader")) // Kader'i bul ve index numarasını ver
// Çıktı -> 0

console.log('------------------------------------')

console.log(people.indexOf(1))
// Çıktı -> 6

console.log('------------------------------------')

console.log(people.indexOf(1, 9))
// Çıktı -> -1, dokuzuncu elemandan sonra 1 değerine denk gelmemiş

console.log('------------------------------------')

console.log(people.indexOf(1, 3))
// Çıktı -> 6, üçüncü elemandan sonra 1 değerinin index numarası