# Projecte-Interactius
Codi del projecte de sistemes interactius

Enrecordeu-vos de fer reset dels components de cada objecte al crear-los.

##### TO-DO
- Treure carpetes innecessaries. En principi amb Assets i ProjectSettings ja hauria de ser suficient (més tot el que sigui de git).

- Netejar scripts - alguns no són usats però no sé si es poden treure.

##### END OF TO-DO

### Update 1 - 9/5/2020 - 18:45

- Les parts dels cos que es detecten son objectes amb un **fill Arma**. Important per poder fer rotacions facilment.
- Creat un nou TAG anomenat 'Weapon'. Les armes tenen aquest tag 
- **Script ZRotateAdjust** creat. Rota l'objecte en el que estigui usant l'angle entre el vector eix.y i ending-origin (només x,y). La rotació es fa en l'eix z. Les parts del cos tenen el script, NO les armes. Facilita la rotació.

- Organització de carpetes amb els fitxers
- Afegit gitignore

### Update 0 - HELLO WORLD
