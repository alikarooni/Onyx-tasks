const Validationerror = ({error}) => {
  return (
    <div 
      className="error"
      style={error === "Valid" ? 
              {color: 'black', borderColor: "steelblue"} :
              {color: "red", borderColor: "red"}
              }>
      {error}
    </div>
  )
}

export default Validationerror