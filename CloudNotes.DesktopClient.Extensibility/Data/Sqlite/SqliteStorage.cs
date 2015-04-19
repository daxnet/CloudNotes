//  =======================================================================================================
// 
//     ,uEZGZX  LG                             Eu       iJ       vi                                              
//    BB7.  .:  uM                             8F       0BN      Bq             S:                               
//   @X         LO    rJLYi    :     i    iYLL XJ       Xu7@     Mu    7LjL;   rBOii   7LJ7    .vYUi             
//  ,@          LG  7Br...SB  vB     B   B1...7BL       0S i@,   OU  :@7. ,u@   @u.. :@:  ;B  LB. ::             
//  v@          LO  B      Z0 i@     @  BU     @Y       qq  .@L  Oj  @      5@  Oi   @.    MB U@                 
//  .@          JZ :@      :@ rB     B  @      5U       Eq    @0 Xj ,B      .B  Br  ,B:rv777i  :0ZU              
//   @M         LO  @      Mk :@    .@  BL     @J       EZ     GZML  @      XM  B;   @            Y@             
//    ZBFi::vu  1B  ;B7..:qO   BS..iGB   BJ..:vB2       BM      rBj  :@7,.:5B   qM.. i@r..i5. ir. UB             
//      iuU1vi   ,    ;LLv,     iYvi ,    ;LLr  .       .,       .     rvY7:     rLi   7LLr,  ,uvv:  
// 
// 
//  Copyright 2014-2015 daxnet
//  
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  
//      http://www.apache.org/licenses/LICENSE-2.0
//  
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//  =======================================================================================================

namespace CloudNotes.DesktopClient.Extensibility.Data.Sqlite
{
    using System.Data.Common;
    using System.Data.SQLite;
    using Apworks.Storage;
    using Apworks.Storage.Builders;

    /// <summary>
    /// Represents the storage of Sqlite database.
    /// </summary>
    internal sealed class SqliteStorage : RdbmsStorage
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="SqliteStorage"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="mappingResolver">The mapping resolver.</param>
        public SqliteStorage(string connectionString, IStorageMappingResolver mappingResolver)
            : base(connectionString, mappingResolver)
        {
        }
        #endregion

        #region Protected Methods

        /// <summary>
        /// Creates a instance of the command object.
        /// </summary>
        /// <param name="sql">The SQL statement used for creating the command object.</param>
        /// <param name="connection">The <see cref="T:System.Data.Common.DbConnection" /> which represents
        /// the database connection.</param>
        /// <returns>
        /// The instance of the command object.
        /// </returns>
        protected override DbCommand CreateCommand(string sql, DbConnection connection)
        {
            return new SQLiteCommand(sql, connection as SQLiteConnection);
        }

        /// <summary>
        /// Creates the database connection.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Data.Common.DbConnection" /> instance which represents
        /// the open connection to the relational database.
        /// </returns>
        protected override DbConnection CreateDatabaseConnection()
        {
            return new SQLiteConnection(this.ConnectionString);
        }

        /// <summary>
        /// Creates a database parameter object.
        /// </summary>
        /// <returns>
        /// The instance of database parameter object.
        /// </returns>
        protected override DbParameter CreateParameter()
        {
            return new SQLiteParameter();
        }

        /// <summary>
        /// Creates a new instance of the where clause builder.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <returns>
        /// The instance of the where clause builder.
        /// </returns>
        protected override WhereClauseBuilder<T> CreateWhereClauseBuilder<T>()
        {
            return new SqliteWhereClauseBuilder<T>(this.MappingResolver);
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a <see cref="T:System.Boolean" /> value which indicates
        /// whether the Unit of Work supports MS-DTC.
        /// </summary>
        public override bool DistributedTransactionSupported
        {
            get { return false; }
        }
        #endregion
    }
}