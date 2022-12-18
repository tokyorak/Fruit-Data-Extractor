SELECT
                -- aff.idAffiliation  AS  idAffiliation,
                -- ct.idContrat  AS  idContrat,
                ptf.CodeEntite  as  CodeEntite,
                if(isnull( ct.CodePTFderog ), ct.CodePTF, ct.CodePTFderog ) AS CodePTF,
                ct.CodeSPTF AS  CodeSPTF,
                ct.NumContrat AS Contrat,
                ct.NumSousContrat AS SCont,
                -- concat_ws('/ ', ct.NumContrat, ct.NumSousContrat ) AS ContratScont,
                ct.CodeRegime AS REGIME,
                ct.CodeStatut AS StatutContrat,
                ct.DateStatut AS DateStatutContrat,
                aff.NumAffiliation AS NumAff,
                aff.StatutContrat,
                -- if(aff.StatutContrat = 'MED',aff.StatutContrat, if(aff.StatutContrat = 'CLO', 'Clos', 'Actif')) AS StatutDossier,
                per.NumPersonne AS NumPER,
                per.Nom AS NOM,
                per.Prenom AS PRENOM,
                mb.OuvrantDroit,
                eier.CotisationAnnuelle,
                eier.Montant AS MNT_ECHANCIER,
                mot.LibMotifCalcul AS MotifCalcul,
                eier.DateCalcul,
                year(eier.DateDebutEcheancier) AS EXERCICE
FROM
                contrat ct
                join echeancier eier
                join affiliation aff
                join membre mb
                join entite ej
                join portefeuille ptf
                join regime rg
                join personne per
                join motifcalcul mot
WHERE
                ct.idContrat = aff.idContrat
                -- and concat(NumContrat,NumSousContrat) in ('22828810000','25270140000','46069820000','68204600000','77031100000','77534100000','78593600000','90578400000')
                and aff.idAffiliation = eier.idAffiliation
                and aff.idAffiliation = mb.idAffiliation and mb.OuvrantDroit = 'O'
                and mb.idPersonne = per.idPersonne and per.CodeEtat <> 'S'
                and ptf.CodePTF = if(isnull(ct.CodePTFderog), ct.CodePTF, ct.CodePTFderog)
                and ej.CodeEntite = ptf.CodeEntite
                and ct.CodeRegime = rg.CodeRegime
                and eier.DateCalcul = '2022-12-19' /* ou eier.DateCreate >= '2019-02-01'*/
                and eier.idMotifCalcul = mot.idMotifCalcul
                -- and ptf.CodeEntite = 'G'
ORDER BY NumContrat,NumSousContrat,aff.idAffiliation, eier.DateCalcul asc;
-- ORDER BY  ptf.CodeEntite, ct.idContrat, aff.idAffiliation desc ;
