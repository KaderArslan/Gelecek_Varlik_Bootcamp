import React, { useState, useEffect } from "react";
import axios from '../../Services/axios';

import Styled from './AddToDo.styled'

const AddToDo = () => {

  const [todoList, setTodoList] = useState([]);

  useEffect(() => {
    axios
    .get('http://localhost:80/todo')
    .then((response) => {
      setTodoList(response.data);
    });
    }, [])

    console.log({ todoList });

  return (
    <Styled>

        <table id="customers">
          <thead>
            <tr>
              <th>ToDo Title</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            
            {todoList.map((todo, index) => {
              return (<tr key={todo.id}>
                <td>{index+1}</td>
                <td>{todo.title}</td>
                <td>{todo.categoryId}</td>
                <td>{todo.statusId}</td>
                <td>
                  <div>
                    <button>View</button>
                    <button>Edit</button>
                    <button>Delete</button>
                  </div>
                </td>
              </tr>)
            })}
              

          </tbody>
        </table>

    </Styled>
  );
};

export default AddToDo;
