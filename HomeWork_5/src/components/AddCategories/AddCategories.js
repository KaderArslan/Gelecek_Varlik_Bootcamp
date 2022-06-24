import React, { useState, useEffect } from "react";
import axios from '../../Services/axios';
// import axios from 'axios';

import Styled from './AddCategories.styled'

const AddCategories = () => {

  const [categoryList, setCategoryList] = useState([]);

  useEffect(() => {
    axios
    .get('http://localhost:80/category')
    .then((response) => {
      // console.log(response.data);
      setCategoryList(response.data);
    });
    }, [])

    // console.log({ categoryList });
    // console.log( categoryList );

  return (
    <Styled>

        <table id="customers">
          <thead>
            <tr>
              <th>Category Title</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            
            {categoryList.map((category, index) => {
              return (<tr key={category.id}>
                <td>{index+1}</td>
                <td>{category.title}</td>
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

export default AddCategories;
