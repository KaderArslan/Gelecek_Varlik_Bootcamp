import React, { useState } from 'react'

import AddToDo from '../AddToDo/AddToDo'
import AddCategories from '../AddCategories/AddCategories'

function ToDo() {

  const [tab, setTab] = useState("todo")
  const [categories, setCategories] = useState([])
  const [todos, setTodos] = useState([])

  const handleToDoEkle = (title) => {
    setTodos([
      ...todos,
      { title: title },
    ])
  }

  const handleCategoryEkle = (title) => {
    setCategories([
      ...categories,
      { title: title },
    ])

  }

  return (
    <div>

      <button onClick={() => setTab("todo")}>Todolar</button>
      <button onClick={() => setTab("categories")}>Kategoriler</button>

      <>

        {tab === "todo" ? 

        <div><AddToDo onSave={handleToDoEkle} />
        </div>
        // <div><CategoryForm /></div>
        : 

        <div><AddCategories onSave={handleCategoryEkle} />
        </div>}

      </>

    </div>
  )
}

export default ToDo
