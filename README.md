# 架構
使用net.core開發,將邏輯與資料層分開處理,方便執行UNITEST與資料層的抽換.
使用Dapper做為ORM,並將將CSV匯入SQLITE加快速度並減少直接讀取CSV造成IO及效能問題

# URL
HOST/api/Products/Grouping/UnblendedCost/{usageaccountid}

HOST/api/Products/Grouping/UsageAmount/{usageaccountid}

# schema
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- 表：Billing
DROP TABLE IF EXISTS Billing;

CREATE TABLE Billing (
    ID             INT      UNIQUE
                            PRIMARY KEY
                            NOT NULL
                            COLLATE BINARY,
    LineItemId     STRING   NOT NULL
                            COLLATE BINARY,
    PayerAccountId STRING   NOT NULL
                            COLLATE RTRIM,
    UnblendedCost  DOUBLE   NOT NULL
                            COLLATE BINARY
                            DEFAULT (0),
    UnblendedRate  DOUBLE   NOT NULL
                            COLLATE BINARY,
    UsageAccountId STRING   NOT NULL
                            COLLATE RTRIM,
    UsageAmount    DOUBLE   NOT NULL
                            COLLATE BINARY,
    UsageStartDate DATETIME NOT NULL
                            COLLATE BINARY,
    UsageEndDate   DATETIME NOT NULL
                            COLLATE BINARY,
    ProductName    STRING   NOT NULL
                            COLLATE RTRIM
);


-- 索引：sqlite_autoindex_Billing_1
DROP INDEX IF EXISTS sqlite_autoindex_Billing_1;

CREATE INDEX sqlite_autoindex_Billing_1 ON Billing (
    ID COLLATE BINARY
);


COMMIT TRANSACTION;
PRAGMA foreign_keys = on;

# PS
因SQLITEDB大小超過100M 故未上傳檔案
