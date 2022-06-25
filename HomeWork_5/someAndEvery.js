/*
array içindeki elemanları bir şarta tabi tutuyorsak 
* some arraydeki elemanların şartımıza uygun en az 1 tane kayıt bile varsa some return olarak true döner yoksa false verir
* every uyguladığımız şarta bütün elemanların uymasını bekler. Eğer 1 tane bile uymayan varsa return olarak false döner
*/

import people from './data.js';

  // .some()

  let result = people.some(item => item.gender == "woman" && item.age > 23);
  console.log("Result gender == woman and age > 23", result); // true

  result = people.some(item => item.gender == "none");
  console.log("Result gender == none", result); // false
  
  // .every()

  result = people.every(item => item.age > 10);
  console.log("Result age > 10", result); // true

  result = people.every(item => item.gender == "woman");
  console.log("Result gender == woman", result); // false

  // hasOwnProperty name özelliği var mı
  result = people.every(item => item.hasOwnProperty("name"));
  console.log("Result hasOwnProperty name", result); // true
  