# Student Register Management
## Kullanılan Teknolojiler Ve Araçlar
Geleneksel katmanlı mimari yaklaşımı ile geliştirilen bir  RESTful API projesidir..NET 7 kullanılmış, ORM aracı olarak EntityFramework Core tercih edilmiştir.
İlişkisel veri yapısı kurularak SQL Lite veritabanı kullanılmıştır.
Yanı sıra Generic Repository ve Unit of Work tasarım kalıpları kullanılarak, veri tabanı ile olan veri akışının merkezileştirilmesi planlanmıştır.
## Proje Amacı ve İlişkisel Yapı 
Öğrenci kayıt sistemi amacıyla tasarlanan projede ; Öğrenci bilgileri, öğrencin aldığı dersler ve derse ait not kayıtları tutulabilmektedir.
### İlişkisel Yapı
Bir öğrencinin alabileceği birden çok ders olabileceği gibi bir derse birden fazla öğrenci kayıt edilebilmektedir. 
</br>
Her bir derse ait de birden fazla not bilgisi tutulabilecektir.
</br>
- **Student** ==> n----n <== **Lesson**  Student ile Lesson arasında çoka çok olacak şekilde ilişki vardır.
- **Lesson** ==> 1---n <== **Notes** Lesson ile Notes arasında bire çok olacak şekilde ilişki vardır.

## EnpPoint'ler ve Örnek Veriler
### - api/Home/CreateStudent 
Bu endpoint ile Öğrenci bilgileri, öğrencinin aldığı dersler ve derslere ait notlar oluşturabilmektedir.
</br>
İstenirse sadece öğrenci bilgileri kaydedilebilmektedir aynı zamanda.
#### Örnek Json Veri : 
```
{
  "name": "Hakan",
  "surName": "Kaban",
  "age": 28,
  "gender": 0,
  "birthDay": "2023-07-27",
  "size": 180,
  "lessonCreateDTOs": [
    {
      "lessonName": "Fizik",
      "explanation": "Lise1Fizik",
      "notesCreateDTOs": [
        {
          "score": 100,
          "explanation": "1.Sınav"
        },
       {
          "score": 90,
          "explanation": "2.Sınav"
        }
     
      ]
    },
     {
      "lessonName": "Matematik",
      "explanation": "Lise1Matematik",
      "notesCreateDTOs": [
        {
          "score": 100,
          "explanation": "1.Sınav"
        },
       {
          "score": 90,
          "explanation": "2.Sınav"
        }
     
      ]
    }
  ]
}
```
###  api/Home/CreateLesson
Bu endpoint ile yeni dersler oluşturabilir , istenilerse eklenecek ders var olan bir öğrenci ile ilşkilendirilebilir.
İstenirse notlar eklenebilir.
#### Örnek Json Veri : 
```
{
  "lessonName": "Deneme",
  "explanation": "DenemeAciklama",
  "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "notesCreateDTOs": [
    {
      "score": 1000,
      "explanation": "Not"
    }
  ]
}
```
###  api/Home/GetAllStudent
Bu endpoint ile öğrenci kayıtları sorgulanmaktadır. 
Öğrenci ile ilgli kayıtda alanların doluluk oranına göre yüzdesel bir hesaplama yapmakta ve yüzdeye göre en dolu profili en üstte göstermektedir.
#### Örnek Json Veri : 
```
{
  "data": [
    {
      "name": "string",
      "surName": "6 alan dolu",
      "age": 28,
      "gender": 0,
      "birthDay": "2023-07-27",
      "size": 180,
      "profileRate": 100
    },
    {
      "name": "string",
      "surName": "5 alan dolu",
      "age": 28,
      "gender": 0,
      "birthDay": "2023-07-27",
      "size": null,
      "profileRate": 83
    },
    {
      "name": "string",
      "surName": "4 alan dolu",
      "age": 28,
      "gender": 0,
      "birthDay": null,
      "size": null,
      "profileRate": 66
    },
    {
      "name": "string",
      "surName": "3 alan dolu",
      "age": 28,
      "gender": null,
      "birthDay": null,
      "size": null,
      "profileRate": 50
    },
    {
      "name": "Hakan",
      "surName": "2 alan dolu",
      "age": null,
      "gender": null,
      "birthDay": null,
      "size": null,
      "profileRate": 33
    }
  ],
  "error": null
}
```
**Not:** Student Ve Lesson entityleri için update ve delete işlemleri yapılabilcek endpointler bulunmaktadır. Bu endpointlerin örnek verilerler açıklanmasına ihtiyaç duyulmamıştır.
