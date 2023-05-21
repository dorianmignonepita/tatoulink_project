# tatoulink_project

Avant de commencer, nous vous conseillons d'avoir un autre compte utilisateur sur votre session Windows.

---
## Concernant la partie base de données, veuillez suivre les étapes suivantes :


### La création de la base se fera de cette manière

1) Créer une base de données vide sur SSMS.
2) Puis passer par le projet Database : 
    - Aller des les propriétés de Database.
    - Dans la nouvelle fenêtre, sélectionner l'onglet 'Débogage'. Puis aller dans la partie 'Chaîne de connexion cible', et cliquer sur 'Modifier'. 
    - Sélectionner dans la nouvelle fenêtre, une base de données vide de préférence.
    - Après avoir validé votre choix, aller dans l'onglet 'Générer' (6ème onglet partant de la gauche en haut de votre éditeur Visual Studio). Une liste déroulante se présentera et cliquer sur 'Déployer la solution'.

### La partie de la configuration de l'utilisateur se mettra en place ainsi : 
1) Dans la partie sécurité de votre serveur SQL, ajouter une connexion qui possède le nom de votre 'autre' utilisateur.
2) Dans la partie sécurité de votre base de données : 
      - Ajouter un utilisateur qui a le nom de votre 'autre' utilisateur.
      - Dans les propriétés de l'utilisateur : 
        - Ajouter les droits sur 'db_owner' dans "Schémas appartenant à un rôle" ainsi que "Appartenance".
        - Donner les droits sur dbo dans "Elements sécurisables".

## Voici ci-dessous les étapes pour la partie IIS : 
1) Dans "Pools d'applications", ajouter un nouveau pool avec les options suivantes :  
      - Le nom que vous souhaitez avoir.
      - Mettre la version du CLR .NET à "Aucun code managé".
      - Mode pipeline gérée à intégrer.

2) Par la suite dans 'Sites', ajouter un site avec la configuration suivante : 
      - Le nom du site que vous souhaitez avoir.
      - Le Pool d'applications que vous avez créé précédemment.
      - Le chemin physique vers le dossier source donné (nous vous recommandons de mettre ces fichiers dans C:\inetpub\wwwroot).
      - Ne pas changer les champs : type, adresse ip et port.
      - Pour le nom de l'hôte, mettez ce que vous voulez avoir.
3) Configuration du fichier Host : 
    - Aller chercher le fichier : 
    
            C:\Windows\System32\drivers\etc\hosts
        Et ajouter en mode administrateur une ligne composée de : 
        
            127.0.0.1 
        Suivie de votre nom d'hôte donner dans la partie ci-dessus.
        - Exemple : 

            127.0.0.1 mti.fr