## 🚀 GitHub Actions

GitHub Actions, GitHub tarafından sağlanan bir CI/CD (Continuous Integration / Continuous Deployment) aracıdır. Yazılım geliştirme süreçlerinde, kodun test edilmesi, derlenmesi, dağıtılması gibi işlemleri otomatikleştirmek için kullanılır.

### ⚙️ GitHub Actions ile Neler Yapılabilir?

Kod pushlandığında veya pull request açıldığında otomatik test çalıştırma
Yazılımı belirli bir ortama otomatik olarak deploy etme (örneğin: AWS, Azure, FTP)
Kod kalitesini denetleme (örneğin: lint, format kontrolü)
Otomatik sürüm oluşturma ve GitHub Releases yayınlama
Cron ile zamanlanmış görevler çalıştırma (örneğin: her gün saat 12:00’de çalışan bir işlem)

### 🧠 Github Actions Temel Kavramlar

#### 🔁 CI (Continuos Integration - Sürekli Entegrasyon)

Yazılım geliştirme sürecinde geliştiricilerin sık sık (genellikle her commit'te) kodlarını merkezi bir depoya entegre ettikleri bir yöntemdir. Amaç, küçük parçalar hâlinde yapılan değişiklikleri anında test etmek ve potansiyel hataları erken aşamada tespit etmektir.

#### CI Ne İşe Yarar?

Her kod gönderimi (commit/push) sonrası otomatik test çalıştırır.
Kodun bozulup bozulmadığını erken aşamada fark ettirir.
Ekip içinde entegre edilen kodların çakışmasını engeller.
Kod kalitesini artırır, hataları azaltır.

Özetle, CI, kodun sürekli olarak test edilmesini ve bütünleştirilmesini sağlar. Testler ve build işlemleri genellikle CI sürecinin temel parçasıdır.

#### 🚀 CD (Continuous Delivery / Continuous Deployment)

Kodların onaylı(delivery) ya da testleri geçerse otomatik olarak canlıya dağıtılması(deploymnet) sürecidir.

#### 🧾 Workflow

Workflow, GitHub Actions içinde otomasyon sürecini tanımlayan bir YAML dosyasıdır.Bir projenin CI/CD süreçlerini, test, build, deploy gibi adımlarını hangi olaylarla (trigger) başlayacağını ve hangi adımların çalışacağını belirler.

Özetle, “Ne zaman, ne olacak, nasıl olacak?” sorularının cevabını veren dosyadır. Workflow, otomasyon sürecinin tamamını tanımlar.

#### 🧩 Action

Action, GitHub Actions içinde tekrar kullanılabilir küçük otomasyon parçalarıdır.Bir işi yapan modül gibidir. Örneğin: Kodu checkout etmek,Node.js kurulumu yapmak,Docker imajı oluşturmak,Slack'e mesaj atmak,bunların hepsi birer "action" olabilir.

#### 🏃 Runner

Runner, bir GitHub Actions workflow’un içindeki işleri (jobs) fiziksel olarak çalıştıran makinedir.Workflow dosyanı yazarsın, job'lar ve step'ler belirlidir. Ama onları gerçekten çalıştıran, testleri koşturan, kodu build eden bir yer gerekir. İşte o yer = runner.

#### 🔔 Event

Event, GitHub Actions'da bir workflow’u tetikleyen (başlatan) olaydır.
Örneğin: Bir kullanıcı kod push’ladığında,Pull request açıldığında,Issue oluşturulduğunda,Bir zamanlayıcı (cron) çalıştığında,Workflow elle başlatıldığında

## Örnek Bir Projeyi Github Actions ile Dockerhub'a Deploy Etmek

1- Web api projeni oluştur (web-app)
2- Web apini test edecek xUnit projeni oluştur (web-app-test)
3- Örnek bir api yaz (ProductsController)
4- web-app-test de birim testini yapabilmek için bağımlılıkları ekle (moq, microsoft.asnetcore.mvc)
5- Test sınıfını yaz ProductControllerTests
6- Projenin kök dizinine (.git ile aynı dizine) Dockerfile dosyanı oluştur. (./Dockerfile)
7- Projenin kök dizinine yml dosyanı oluştur. (.github/workflows/build-and-test.yml)
8- Projeyi pushla

Önemli notlar;

1- build-and-test.yml dosyasında;

- on parametresi ile ne zaman hangi branch'ta çalışacağını belirledik
- jobs ile adımları belirledik (github ubuntu ile çalıştırıyor)
- steps ile sırasıyla gerekli bağımlılıkları yükledik bunların her biri actions olarak nitelendiriliyor ve github marketplace'de bulunuyor.
- dockerhub'a bağlanıp push yapabilmek için secret bilgilerimizi github'da belirledikten sonra burada çağırıyoruz.

2- Dockerfile dosyasında;

- Dotnet ile ilgili bağımlılıklar yazılıyor
- .csproj kısmının olduğu klasör yapısı dockerfile'e göre konumlanıyor
- dotnet publish komutu ile publish olup release çıkıyor
- dotnet runtime ile de projeyi indiren bilgisayarlardas çalıştırılması sağlanıyor
