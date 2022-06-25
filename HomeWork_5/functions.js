var isim = "Kader Arslan";

// --- Length Özelliği--- Uzunluk Değerini Alma
// String veri tipinde bulunan bir ifadenin ne kadar uzun olduğunu bulmak için Length özelliğimizi kullanırız.
console.log('length: ',isim.length); // 12

// --- indexOf --- Metin İçinde Arama Yapma
// Metnin içinde aramak istediğimiz değerin index numarasını bize verir.
console.log('indexOf Ars: ',isim.indexOf('Ars'));// 6

// --- lastIndexOf --- Metin İçinde Arama Yapma
// indexOf ile arasındaki tek fark aranan kelime birden fazla geçiyor ise en son eşleşmeden gelen index numarasını döndürür.
console.log('lastIndexOf r: ',isim.lastIndexOf('r'));// 7

// --- Search --- Metin İçinde Arama Yapma
// indexOf ile aynı sonuçlara ulaşırız genel olarak "Regular Expressions" işlemleri için çok kullanılan bir metottur.
console.log('search Ar: ',isim.search('Ar'))// 6

// --- Slice --- Metninden Parça Almak
// Metin içinden almak istediğimiz yerlerin index numaralarını vererek metin içinde bulunan parçayı alabiliriz. Bitiş index numarasındaki karakter sonuca dahil edilmez.
console.log('slice 4,10: ',isim.slice(4,10))// r Arsl

//Not: Tek index yazmak ise yazılan index numarasından sonra gelen tüm karakterleri almasına neden olur.
console.log('slice 2: ',isim.slice(2))// der Arslan

// Replace – Metin Bulma ve Değiştirme
// Aranan metni istediğimiz metin ile değiştirmemize olanak sağlar.
console.log('replace Arslan, Kader: ',isim.replace('Arslan', 'Kader'))// Kader Kader

// toUpperCase metin içinde bulunan tüm karakterleri büyük harf yapmamıza olanak sağlar.
// toLowerCase metin içinde bulunan tüm karakterleri küçük harf yapmamıza olanak sağlar.
console.log('toUpperCase: ',isim.toUpperCase());// KADER ARSLAN
console.log('toLowerCase: ',isim.toLowerCase());// kader arslan

// Concat - Metin Birleştirme
// Elimizde bulunan iki string türündeki veriyi birleştirmemize olanak sağlar.
var ad = 'Kader';
var soyad = 'Arslandev';
console.log('concat Kader Arslandev: ',ad.concat(' ', soyad));// Kader Arslandev

// charAt- İndex Numarasına Göre Karakter Bulmak
// Belirtilen index numarasında yer alan karakteri verir.
console.log('charAt 1: ',isim.charAt(1));// a

// charCodeAt – İndex Numarasına Göre Karakterin Unicode Değerini Bulma
// Belirtilen index numarasında yer alan karakterin Unicode değerini verir.
console.log('charCodeAt 1: ',isim.charCodeAt(1));// 97

// Split – Metni Diziye Çevirme
// Split metodu ile istenilen metin diziye çevrilebilir. Kullanılan parametre ile metnin nasıl parçalanacağı belirtilir.
var isimler = "kader,yasemin,büşra";
var adlar = isimler.split(',');
console.log('isimler: ', isimler);// kader,yasemin,büşra

