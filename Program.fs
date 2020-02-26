open Npgsql.FSharp
open System

let users (connectionString: string) =
    connectionString
    |> Sql.connect
    |> Sql.query "SELECT * FROM users"
    |> Sql.execute (fun read ->
        {|
            userId = read.int "user_id"
            username = read.text "username"
            lastLogin = read.dateTimeOrNone "last_login"
        |})