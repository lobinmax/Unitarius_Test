DECLARE @DtBalance AS DATE = '19870326';

WITH Accounts AS
(
    SELECT abh.AccountUid
    FROM dbo.AccountsBalanceHistory AS abh
    GROUP BY abh.AccountUid
    
),
BalanceMaxDate AS
(
    SELECT 
        abh.AccountUid,
        MAX(abh.DtTimeBalance) AS DtTimeBalance
    FROM AccountsBalanceHistory AS abh
    WHERE CAST(abh.DtTimeBalance AS DATE) < @DtBalance
    GROUP BY abh.AccountUid 
),
AccountsBalance AS 
(
    SELECT a.AccountUid,
           b.DtTimeBalance
    FROM Accounts AS a
    LEFT JOIN BalanceMaxDate AS b
        ON b.AccountUid = a.AccountUid
)

SELECT 
    ab.AccountUid,
    ab.DtTimeBalance,
    abh.Balance
FROM AccountsBalance AS ab
LEFT JOIN dbo.AccountsBalanceHistory AS abh
    ON abh.AccountUid = ab.AccountUid
        AND abh.DtTimeBalance = ab.DtTimeBalance