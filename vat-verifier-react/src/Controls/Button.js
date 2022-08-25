import React from 'react'

const Button = ({text, onclick}) => {
  return (
    <div>
      <button
        className='btn btn-block'
        onClick={()=>onclick()}
        >{text}</button>
    </div>
  )
}

export default Button
