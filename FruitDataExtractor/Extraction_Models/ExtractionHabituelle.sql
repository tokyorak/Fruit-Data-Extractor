-- Statut-Ct
select ct.*,hc.* from contrat ct
join histocontratstatut hc on ct.idContrat = hc.idContrat
where  concat_ws('_',NumContrat,NumSousContrat)= '{0}';

-- Statut-Cb,
select ccb.*,hcb.* from contrat ct
left join contratcb ccb  on ct.idContrat = ccb.idContrat
left join histocbstatut hcb on ccb.idContratCB = hcb.idContratCB
where  concat_ws('_', NumContrat,NumSousContrat)= '{0}';

-- Taux
select cb.CodeCB,cb.CodeGC00,cb.CodeCotisIndiv,cb.CodeSocle,mp.CodeMP,tr.CodeSR,tx.CodeRT,tx.DateDebutTaux,tx.DateFinTaux,tx.OptionTech,
tx.Taux1,tx.Taux2,tx.Taux3,tx.Taux4,tx.CodeAssiette1,tx.CodeAssiette2,tx.CodeAssiette3,tx.CodeAssiette4,tx.CodeFiscal,tx.DateModif,tx.DateCreat,tx.CodeEcart,tx.DateEcart
from contrat c
left join contratcb ccb on c.idContrat = ccb.idContrat
left join histocbstatut hc on hc.idContratCB = ccb.idContratCB
left join tarification tr on tr.idContratCB = ccb.idContratCB
left join cb on cb.CodeCB = ccb.CodeCB
left join tauxglobaux tg on tg.idMP = tr.idMP
left join mp on mp.idMP = tr.idMP
left join taux tx on tx.idTarification = tr.idTarification
where concat_ws('_', NumContrat,NumSousContrat)= '{0}'
group by  tx.idTaux
order by ccb.CodeCB,cb.CodeSocle desc,tr.CodeSR,mp.CodeMP;