
import { useState } from 'react'


const Textbox = ({ label, onchange }) => {
const [value, setText] = useState('')

  return (
    <div className='form-control'>
      <label className='form-control'>{label}</label>
      <input 
        className='form-control'
        type="text" 
        value={value} 
        onChange={(e)=> {setText(e.currentTarget.value); onchange(e.currentTarget.value)}} />

    </div>
  )
}

export default Textbox
