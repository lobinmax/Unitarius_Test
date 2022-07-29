DECLARE @DtBalance AS DATE = '19870326'

SELECT 
    abh.AccountUid,
    abh.DtTimeBalance,
    abh.Balance
FROM dbo.AccountsBalanceHistory AS abh
RIGHT JOIN 
(
    SELECT 
        abh.AccountUid,
        MAX(abh.DtTimeBalance) AS DtTimeBalance
    FROM AccountsBalanceHistory AS abh
    WHERE CAST(abh.DtTimeBalance AS DATE) < @DtBalance
    GROUP BY abh.AccountUid 
) AS abhMax
    ON abhMax.AccountUid = abh.AccountUid
        AND abhMax.DtTimeBalance = abh.DtTimeBalance
