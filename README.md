# Fruit-Data-Extractor

## Description

Une application C# qui va opérer les différentes extractions "habituelles" demandées par la MOA en se basant sur les NumContrat et NumSousContrat fournis par la MOA.
Les contrats seront récupérés dans un fichier de configuration. Tout comme les requêtes SQL (l'utilisateur sera responsable de la cohérence des paramètres demandés par les requêtes ainsi que le type de paramètres disponibles).
Une fois les résultats récupérés dans des listes .csv elles seront compilées dans un fichier .xlsx où l'utilisateur pourra personnaliser le résultat final.

## Parametrage

### NumContrat et NumSousContrat

Les paramètres seront sous un format concaténé.
