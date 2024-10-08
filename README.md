# Guide pour l'utilisation de Git

## Introduction
Ce projet Unity simule un laboratoire de sciences composé de trois salles distinctes :

Salle de Chimie : dédiée aux expériences chimiques.
Salle de Physique : dédiée aux expériences en physique.
Salle Informatique : dédiée aux démonstrations et simulations informatiques.

Comme nous sommes 5 à developper sur ce projet, 
Il est necessaire d'utiliser les branches sur Git.

Cette documentation a pour but d'expliquer le fonctionnement des branches sur Git lors du développement, afin d'éviter les conflits.

### Structure de branches
Nous suivons une organisation basée sur le modèle GitFlow, adaptée aux besoins du projet. Voici un résumé des principales branches utilisées :

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

## Conclusion
Ce guide fournit un cadre pour organiser le développement sur le projet Unity du laboratoire de sciences. Respecter cette structure permettra de maintenir la qualité et la stabilité du projet tout en facilitant la collaboration nous.

