C'est une api de gestion des événement, qui à pour objectif d'aider une équipe ou un commercial à déployer son application

Je suis partie sur un N-tiers, avec une couche de présentation, une couche de persistence de donnée, et métier, et une dernière de ressources, avec tout les enums ou autre du projet.

Chaque tiers Présentation ( Api Rest ) ,
Services ( Bll ) 
Persist ( Dto ) 
Ont leurs propre dto dont ils se servent pour communiquer entre eux.
Idéalement j'aimerais découpler au maximum les projets pour avoir l'ordre de dépendance suivant 

Presentation dépend de -> Services -> Persist


Comment la base de données est écrites ? Osef c'est le projet persist qui gère, Idem service s'en fiche de comment l'appel en base est fait, il reçoit juste un objet c# de la part de Persit.
Il faut néanmoins que je termine de découpler présentation et persist, pour avoir aucune dépendance entre ces deux projets
