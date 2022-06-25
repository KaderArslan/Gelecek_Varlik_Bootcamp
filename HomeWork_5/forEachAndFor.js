//find olmasaydı forEach ile nasıl yapardık

import people from './data.js';
  
people.forEach(item => {
  if (item.age > 30) {
    console.log("forEach", item);
  }
});
//forEach te return ya da break ile dönmeyeceği için for ile yapıyoruz

console.log('------------------------------------')
  
for (let i = 0; i <= people.length - 1; i++) {
  if (people[i].age > 30) {
    console.log("find gibi for", people[i]);
    break;//bu şekilde 1 tane gelir ilkini yani find gibi
  }
}

console.log('------------------------------------')

for (let i = 0; i <= people.length - 1; i++) {
  if (people[i].age > 30) {
    console.log("findIndex gibi for", people[i], i);
    break;//findIndex gibi index numarasını getirir
  }
}