import styled from 'styled-components'

const Styled = styled.div`
#customers {
    border-collapse: collapse;
    width: 100%;
    background-color:#fff;
    box-shadow: 5px 10px 8px #888888;
  }
  
  #customers td {
    border: 1px solid #ddd;
    padding: 8px;
    color:black;
    text-align: left;
  }
  
  #customers tr:nth-child(even){background-color: #f2f2f2;}
  
  #customers tr:hover {background-color: #ddd;}
  th{color:black;
  text-align:left}
  
`

export default Styled






