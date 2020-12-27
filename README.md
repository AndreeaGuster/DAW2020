# Laborator DAW 2020
Dupa ce descarcati proiectele trebuie sa aveti in vedere sa:
* NU uitati sa modificati connectionString din fisierul Web.config atunci cand deschideti proiectele in VS. ConnectionString-ul vostru va contine calea absoluta a proiectului.
## CheckBox-uri pentru relatia Many To Many
* In proiectul laboratorului 5 aveti si un exemplu de checkbox-uri pentru relatia many-to-many dintre Book si Genre, in formularul de creare a unei carti noi
## Relatia One-to-One intre Publisher si ContactInfo
In proiectul laboratorului 5 am creat un exemplu pentru urmatoarea functionalitate:
* Atunci cand cream un publisher nou, vrem ca in acelasi formular sa ne apara si campurile modelului ContactInfo
* In concluzie, in actiunea New din PublisherController vom adauga 2 obiecte in BD: publisher si contactInfo.
## Pentru a prelua id-ul utilizatorului curent. Poate fi accesat si in controller si in view.
```
var currentUserId = User.Identity.GetUserId();
```
## Pentru a verifica daca un utilizator are un rol dat. Poate fi accesat si in controller si view.
```
 bool isAdmin = User.IsInRole("Administrator"); 
 
 // isAdmin = true daca utilizatorul are rolul de Administrator
 // isAdmin = false daca utilizatorul are orice alt rol decat cel Administrator
```