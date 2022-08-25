import { useState } from "react";
import Textbox from "./Controls/Textbox";
import Button from "./Controls/Button";
import ErrorMesage from "./Controls/ErrorMesage";

function App() {
  const [countrycode, setCountrycode] = useState('')
  const [vatnumber, setVatnumber] = useState('')
  const [hasError, setHaserror] = useState('')

  const Verify = async () => {
  
    const result = await fetch(`http://localhost:5000/api/Verify?CountryCode=${countrycode}&vatNumber=${vatnumber}`)
    const data = await result.json()
    console.log(data['result'])
    setHaserror(data['result'])
  }

  return (
    <div className="container">
          <header className="header"><h2>Onyx</h2></header>
          <div className="body">
            <Textbox label={"Country Code"} onchange={setCountrycode} />
            <Textbox label={"Vat Number"} onchange={setVatnumber} />
            <Button text={"Verify"} onclick={()=>Verify()} />

            {hasError.length > 0? <ErrorMesage error={hasError} />: "" }
          </div>
    </div>
  );
}

export default App;
