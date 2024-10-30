# Guide pour l'utilisation de Git

## Introduction
Comme nous sommes 5 à developper sur ce projet, 
Il est necessaire d'utiliser les branches sur Git.

Cette documentation a pour but d'expliquer le fonctionnement des branches sur Git lors du développement, afin d'éviter les conflits vu qu'on travaille toutes sur le memes projets

## Structure de branches

### Branches principales
main  ou master: la branche principale contient le code stable, testé et prêt à être publié. Aucune modification ne doit être faite directement dans cette branche. Tout changement doit passer par une fusion depuis la branche develop ou une branche de correction d'urgence.

develop : cette branche contient les dernières fonctionnalités en cours de développement qui seront testées avant d'être fusionnées dans main. C'est ici que se fait la majorité du travail de développement.

### Branches de fonctionnalité (Feature Branches)
Chaque fonctionnalité ou amélioration de la simulation se fait dans une branche dédiée, dérivée de develop.

Nom de branche : feature/nom-fonctionnalité
Exemples :

feature/chimie-ajout-reactifs
feature/physique-optique-experience
feature/informatique-ui-nouvelle-interface
## Étapes pour créer et travailler sur une branche de fonctionnalité :

### Création de la branche : Créez une branche à partir de develop pour chaque nouvelle fonctionnalité.

```bash
git checkout develop
```
```bash
git pull origin develop
```
```bash
git checkout -b feature/nom-fonctionnalité
```

### Développement : Travaillez sur votre fonctionnalité en local.

### Push de la branche : Une fois la fonctionnalité développée, poussez la branche vers le dépôt distant.

```bash
git add .
```
```bash
git commit -m "Ajout de la fonctionnalité XYZ"
```
```bash
git push origin feature/nom-fonctionnalité
```

### Plus tard Fusionner la branche dans develop. 

- Branches de correction de bugs (Bugfix Branches)
Les bugs identifiés dans develop ou main doivent être corrigés dans des branches dédiées.

Nom de branche : bugfix/nom-bug
Exemples :

bugfix/chimie-collision-objets
bugfix/physique-erreur-equation
Les étapes pour créer et fusionner une branche de bugfix sont similaires à celles des branches de fonctionnalité.


### Créez une branche à partir de main :

```bash
git checkout main
```
```bash
git pull origin main
```
```bash
git checkout -b nomdelabranche
```

Après la correction, mergez la branche dans main et develop 

### Chaque commit doit représenter un changement atomique et spécifique. Évitez les commits trop généraux.

### Commentaires explicites : Utilisez des messages de commits clairs qui expliquent précisément ce qui a été fait.

```bash
git commit -m "Ajout du système de mélange des réactifs dans la salle chimie"
```

Tests : Assurez-vous que toute nouvelle fonctionnalité ou correctif est bien testé dans Unity avant de pousser une branche.

Fusion régulière : Ne laissez pas les branches diverger trop longtemps. Faites des fusions régulières de develop dans vos branches de fonctionnalité pour rester à jour avec les autres développements.

Exemples de flux de travail
Cas d'ajout d'une fonctionnalité à la salle de chimie
Créer la branche :

```bash
git checkout develop
git checkout -b feature/chimie-nouvel-experience
```

Développer et committer :

```
git add .
git commit -m "Ajout de l'expérience sur les réactions acide-base"
git push origin feature/chimie-nouvel-experience
```


Fusion après validation : Une fois approuvée, fusionnez la branche et supprimez-la.

 ## Git et Unity Hub
 
Lorsque qu'on utilises Git et Unity ensemble, chaque branche Git correspond à une version différente du projet Unity. 
Le changement de branche avec Git permet de basculer entre différentes versions du projet, comme des fonctionnalités en cours de développement ou des corrections de bugs. 

Cependant, Unity génère certains fichiers spécifiques (comme ceux dans les dossiers Library, Temp, et Build, marquée dans le git ignore) qui ne doivent pas être suivis par Git, car ils sont propres à l'environnement local.

Lorsqu'on change de branche avec Git (git checkout nom-de-branche), certains fichiers du projet Unity peuvent être modifiés, comme des scripts, des scènes ou des assets. Unity détecte ces changements automatiquement et peut te demander de recharger le projet pour prendre en compte les nouvelles modifications. Il est important de s'assurer que tout est bien commité avant de changer de branche, pour éviter de perdre des modifications non sauvegardées. Si on changes de branche alors que Unity est ouvert, tu devras souvent cliquer sur "Reload" pour rafraîchir l’éditeur et synchroniser le projet avec la nouvelle branche.

Les conflits peuvent survenir lorsque les mêmes fichiers sont modifiés sur plusieurs branches, et Git te demandera de résoudre ces conflits manuellement. Une fois que tout est en ordre, on peut continuer à travailler dans Unity sur la nouvelle branche

## Conclusion
Ce guide fournit un cadre pour organiser le développement sur le projet Unity du laboratoire de sciences. Respecter cette structure permettra de maintenir la qualité et la stabilité du projet tout en facilitant la collaboration nous.

