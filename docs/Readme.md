# LolaFlora

##### Projeyi Ayağa Kaldırmak

Proje Code First mantığıyla oluşturulmuştur. Bu şekilde kod tarafından veri tabanını ayağa kaldırabileceğiz.
Seed ile adı ve şifresi "test" olan bir kullanıcı eklendi.
Veritabanı olarak postgre sql kullanıldı. Hem open source olması hem de platform bağımsız çalışması dolayısıyla seçildi.
Burada context yapısı ile hem farklı projeler için farklı veri tabanları imkanı sağlanmaktadır hem de veri tabanı bağımlılığı kaldırılmıştır.
Yine ileride geçilebilecek microservice yapısına hazırlık olarak da kullanılmak mümkün olabilir.
* add-migration Initial -context PgsqlDbContext -> .net core console için : dotnet ef migrations add MyFirstMigration --context PgsqlDbContext
* update-database -context PgsqlDbContext -> .net core console için : dotnet ef database update --context PgsqlDbContext

#### Yaptığım Kodlama ile ilgili 
1- Tüm işlemlerden önce loglama kuruldu. Serilog tercih edildi. Seq uygulaması ile detaylı arama yapılabilir. 15 microservise kadar loglama desteklemektedir.
2- Global exception kuruldu. Bir middleware oluşturuldu. Her hangi bir exception handle edilemezse en son bu şekilde handle edilmesi sağlanmaktadır.
3- Shared Languages ile çoklu dil desteği alt yapısı kuruldu. Farklı şekillerde customize edilebilir.
4- Swagger kuruldu. Bu sayede tüm model ve uçların otomatik dokümantasyonu hazırlandı.
5- Jwt kuruldu. Authentication sistemi oluşturulan token üzerinden devam edebilecek.

- Integration test kuruldu. WebApplicationFactory ile belirtilen startup dosyasına ayağa kalkmaktadır ve bir akışı mock'sız test edebilmektedir. 
      https://malikmasis.blogspot.com/2020/04/integration-test-net-core-xunit-web.html
	  
- Unit test kuruldu. Unit test mantığı gereği sadece bir metodun test edilmesi gerektiğinde mocklama da kuruldu. Ayrıca farkı girişler için inline data kullanıldı.
       https://malikmasis.blogspot.com/2020/04/birimunit-test-ile-veri-kumeleri-xunit.html

- Unit test yazarken void method yazmamak gibi bazı noktalara da dikkat etmeye özen gösterildi.
       https://malikmasis.blogspot.com/2020/09/void-metodlar-test-etmek.html

- Configuration ile json dosyasından alınan bilgiler IOptions ile type-safe yapıldı.
      https://malikmasis.blogspot.com/2020/04/type-safe-configuration-ioptionsmonitor.html

## Diğer Notlar
- Sonarqube'in client tarafında çalışan sonarlint extension ile teknik borç sıfıra çekildi.
    https://medium.com/software-development-turkey/sonarlint-ile-refactoring-teknik-borcu-azaltma-7d3da6c92f19

- Clr Heap Allocation Analyzer ile bellek yönetimi yapıldı. Kod tarafındaki exlicit açıklaması bununla ilgilidir.
    https://marketplace.visualstudio.com/items?itemName=MukulSabharwal.ClrHeapAllocationAnalyzer&ssr=false#overview

## Eklenebilecekler
- HealthCore ile servislerin çalışırlığını testen eden bir sistem de kurulabilirdi.
     https://malikmasis.blogspot.com/2020/04/health-check-and-monitoring-net-core.html



