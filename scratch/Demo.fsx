// "OR" type (discriminated union)
type AppleVariety =
| GoldenDelicious
| GrannySmith
| Fuji

type BananaVariety =
| Cavendish
| GrosMichel
| Manzano

type CherryVariety = 
| Monmorence
| Bing

// "AND" types
type Fruitsalad = {
    Apple: AppleVariety
    Banana: BananaVariety
    Cherries: CherryVariety
}

// "OR" type (discriminated union)
type FruitSnack =
| Apple of AppleVariety
| Banana of BananaVariety
| Cherries of CherryVariety

// Simple Types: "Choice" types with only *one* choice
//
// type ProductCode = 
// | ProductCode of string
//
// simplified version:
type ProductCode = ProductCode of string

// Optional data
type PersonalName = {
    FirstName: string
    MiddleInitial: string option
    LastName: string
}

// Create an undefined type which can be replaced later...:
type undefined = exn

type UnpaidInvoice = undefined
type Payment = undefined
type PaidInvoice = undefined
type PaymentError = undefined

// Function type: Signature of function
type PayInvoice =
    UnpaidInvoice -> Payment -> Result<PaidInvoice, PaymentError>