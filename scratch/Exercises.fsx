type Customer = {
    Id: int
    IsVip: bool
    Credit: decimal
}

let customer = { Id = 1; IsVip = false; Credit = 10M }

let tryPromoteToVip (customer:Customer, purchases:decimal) =
    if purchases > 100M then { customer with IsVip = true }
    else customer

let getPurchases customer =
    match customer.Id % 2 with
    | 0 -> customer, 120M
    | _ -> customer, 80M

let increaseCredit f customer =
    match f customer with
    | true -> { customer with Credit = customer.Credit + 100M }
    | false -> { customer with Credit = customer.Credit + 50M }
