Çalıştırdığım sistemin ekran görüntüleri klasör altındadır.
Vakit problemi yaşadığım için arama ve ekran çıktısı alma kısımlarını yapamadım. 

Proje tasarımı olarak uzun zamandır kendi projelerimde de kullanmaya çalıştığım Onion Architecture mimarisinin biraz basitleştirilmiş hali şeklinde yapmaya çalıştım. Modelleri ayırdım, service ve repository kullandım. 

Tanımlamalara, validasyonlara ve veritabanı alanlarının boyut ve tip düzenlemelerini eklemedim. Ayrıca javacript ile herhangi bir çalışma yapmadım. Normalde istemci tarafında da kontroller, vs. yapılması gereklidir. Kayıt gerçekleştirilebilmesi için ekranda görülen alanların doldurulması gerekmektedir. 

CodeFirst yaklaşımı ile veritabanını EntityFramework ile oluşturdum. Migration eklerken Migration verilerinin Persistence altında tutulabilmesi için aşağıdaki komutu kullandım.
Add-Migration Mig_1_Initial -OutputDir Infrastructure/Persistence/Migrations

Veritabanı olarak VMware Workstation'da sanal olarak kurulu olan Ubuntu işletim sistemi içerisinde Docker container olarak MSSQL kullandım. Proje dokümanında tercihen PosgreSQL yazıyordu. Fakat benim elimde halihazırda MSSQL olduğu için ben onu kullandım. Fakat PosgreSQL kullanılması durumunda herhangi bir kod düzenlemesi gerekmemesi açısından Id değerlerini Guid olarak belirledim. Sadece PosgreSQL kullanımı için gerekli paketlerin kurulması ve ayarların yapılması yeterlidir. Herhangi bir kod değişikliğine gerek yoktur.
Ayrıca her işlemin Program.cs içerisinde olmaması için PersistenceServiceRegistration isimli bir class oluşturdum ve DI dış servis ve veritabanı ayarlarını o bölümden yaptım.

Ekranlardaki listelemelerde tip görüntülenen yerlerde Id değerleri görünmektedir. Normal bir uygulamada bu kısımlarda mutlaka değeri görüntlenmesi gerekmektedir. Bu projede kodlama ve tasarım yeteneklerimin ön planda olmasını istediğim için bu konularda fazla zaman harcamadım.

Web projesinde api url'si için appsetting.json dosyası içerisinde ApiUrl isimli bir anahtar bulunmaktadır. Projeyi kendinizde çalıştırdığınızda api projesinin urlsinde bir değiliklik olması durumunda bu değeri değiştirmeniz yeterli olacaktır.

Kolay gelsin.

Herhangi bir sorunuz olması durumunda benimle her zaman iletişime geçebilirsiniz.
