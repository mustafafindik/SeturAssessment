# SeturAssessment

### Notlar
- ReportService'deki Appsetting.Json içinde, Db Bağlantı içi  ConnectionString (PostgreSql) ve RabbitMQ için MessageBrokerOptions değerlerini Değiştirin. 
- ContactService'deki Appsetting.Json içinde, Db Bağlantı içi  ConnectionString (PostgreSql) ve RabbitMQ için MessageBrokerOptions değerlerini Değiştirin.
- (İki MessageBrokerOptions içindeki QueueName Aynı Olmalı)
- SeedData Eklendi.
- Migration'lar Otomatik Uygulanıyor.
- Projelerin ikisini Beraber Çalıştırınız..

______

- Zaman Azlığından UnitTest , FluentValidation ,Serilog ,Jwt kullanılmamıştır. Zaman olsaydı Ekleyecektim.

 
### Teknolojiler
- .NetCore WebApi
- Autofac IoC
- AutoMapper
- RabbitMQ
- Swagger
- PostgreSql


### ContactService
-- Base : https://localhost:44355

- /api/Contacts : Tüm Rehberdeki Kişileri Çeker
- /api/Contacts/{id} : Verilen Id'e ait Kişiyi Çeker.
- /api/Contacts/add : Rehbere Kişi Ekler
- /api/Contacts/update : Rehberdeki Kişiyi günceller
- /api/Contacts/delete/{id} : Verilen Id'e ait Kişiyi Siler.

- /api/ContactDetails/add/{contactId} : Verilen ContactId'e İletişim Bilgisi Ekler.
- /api/ContactDetails/update/{contactId}   : Verilen ContactId'e İletişim Bilgisini Günceller.
- /api/ContactDetails/delete/{contactDetailId} : Verilen ContactDetailId'e İletişim Bilgisini Siler.

- /api/ReportRequests/RequestReport : Tüm Lokasyonlar için Rapor İsteği Yapar. (RabbitMq Producer)
- /api/ReportRequests/RequestReport/{location} : Verilen Lokasyon için Rapor İsteği Yapar  (RabbitMq Producer)

### ReportService
-- Base: https://localhost:44303   (RabbitMq Consumer Background)

- /api/Reports : Tüm Raporları Getirir. 
- /api/Reports/{id} : Verilen Id'e ait raporları getirir.  
