# Pendu1.0
# Jeu du Pendu


## **Description**
Ce projet est une implémentation du célèbre jeu du Pendu développé en C#. L'application permet aux joueurs de deviner un mot lettre par lettre, avec un nombre limité d'erreurs autorisées (3). Le mot à deviner est récupéré aléatoirement à partir d'une liste.


## **Technologies utilisées**
- Langage de programmation: C# (.NET 9.0)

## **Logiciels requis**

- Visual Studio 2022 (version 17.0 ou supérieure)
- SDK .NET 9.0
- Android SDK (pour le développement Android)
- Xcode (pour le développement iOS/macOS, uniquement sur Mac)
- Windows (pour le développement sur Windows)


## **Fonctionnalités**

- Interface utilisateur intuitive avec navigation entre pages
- Récupération de mots aléatoires à partir d'une liste
- Système de vies (10 tentatives maximum)
- Visualisation graphique du pendu qui évolue avec les erreurs
- Affichage des lettres incorrectes déjà essayées
- de victoire et de défaite ????
- Possibilité de rejouer ou de quitter à la fin d'une partie



## **Installation et exécution**

# Prérequis
- Visual Studio 2022 


# Étapes d'installation

Visual Studio :
- Cloner le dépôt ou télécharger les fichiers source
- Ouvrir la solution Pendu1.sln dans Visual Studio
- Restaurer les packages NuGet (clic droit sur la solution > Restaurer les packages NuGet)
- Sélectionner la plateforme cible (Android, iOS, Windows) dans la barre d'outils
- Compiler et exécuter l'application (F5)

Visual Studio Code :
- Cloner le dépôt ou télécharger les fichiers source
- Ouvrir la solution Pendu.sln dans Visual Studio Code
- Dans votre teminale aller jusqu'au dossier Pendu
- Faite un dotnet add package Newtonsoft.Json
- Ensuite, faite dotnet build
- Pour afficher l'interface taper :dotnet build -t:Run -f net9.0-windows10.0.19041.0



## **Règles du jeu**

- Un mot aléatoire est choisi au début de chaque partie
- Le joueur a 3 tentatives pour deviner le mot
- À chaque erreur, une partie du pendu est dessinée
- Le joueur gagne s'il devine toutes les lettres avant que le pendu ne soit complètement dessiné
- Le joueur perd s'il fait 3 erreurs 



## **Contribution**

# Pour contribuer à ce projet:

1. Forker le projet
2. Créer une branche pour votre fonctionnalité (git checkout -b feature/amazing-feature)
3. Committer vos changements (git commit -m 'Add some amazing feature')
4. Pousser vers la branche (git push origin feature/amazing-feature)
5. Ouvrir une Pull Request
