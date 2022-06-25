import people from './data.js';

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
console.log('------------------------------------------')

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
