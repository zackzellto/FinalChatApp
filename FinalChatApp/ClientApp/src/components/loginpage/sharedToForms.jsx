import styled from "styled-components";

export const BoxContainer = styled.div`
    width: 100%;
    display: flex;
    flex-direction: column;
    align-items: center;
   
`;

export const FormContainer = styled.form`
    width: 100%;
    display: flex;
    flex-direction: column;
    
`;

export const MutedLink = styled.a`
    font-size: 16px;
    color: linear-gradient(90deg, rgba(2,0,36,1) 0%, rgba(9,9,121,1) 35%, rgba(0,212,255,1) 100%);
    font-weight: 500;
    text-decoration: none;
    
`;

export const BoldLink = styled.a`
    font-size: 16px;
    color: linear-gradient(90deg, rgba(2,0,36,1) 0%, rgba(9,9,121,1) 35%, rgba(0,212,255,1) 100%);
    font-weight: 800;
    text-decoration: none;
`;

export const Input = styled.input`
height: 60px;
margin: 10px;
filter: drop-shadow(6px 6px 3px #0566e4);
  background: #ffffff;
  color: #5e84d6;
  border-radius: 100px 100px 100px 100px;
  border: 1px solid #d1d1d1;
  box-shadow: inset 1px 2px 8px rgba(14, 116, 199, 0.07);
  font-family: inherit;
  font-size: 1em;
  line-height: 1.45;
  outline: none;
  padding: 0.6em 1.45em 0.7em;
  -webkit-transition: .18s ease-out;
  -moz-transition: .18s ease-out;
  -o-transition: .18s ease-out;
  transition: .18s ease-out;
   

    &::placeholder {
        font-size: 18px;
    
        color: linear-gradient(90deg, rgba(2,0,36,1) 0%, rgba(9,9,121,1) 35%, rgba(0,212,255,1) 100%);
    }

    &:hover{
        box-shadow: inset 1px 2px 8px rgba(0, 0, 0, 0.02);
    }

    &:focus {
        color: #3156a0;
  border: 1px solid #B8B6B6;
  box-shadow: inset 1px 2px 4px rgba(0, 0, 0, 0.01), 0px 0px 8px rgba(0, 0, 0, 0.2);
    }
`

export const SubmitButton = styled.button`
    width: 100%;
    height: 60px;
    padding: 11px 40%;
    color: #fff;
    font-size: 18px;
    font-weight: 600;
    border: none;
    position: relative;
    border-radius: 100px 100px 100px 100px;
    cursor: pointer;
    transition: all, 240ms ease-in-out;
    filter: drop-shadow(6px 6px 3px #0566e4);
    background: rgb(2,0,36);
background: linear-gradient(90deg, rgba(2,0,36,1) 0%, rgba(9,9,121,1) 35%, rgba(0,212,255,1) 100%);

&:hover {
    filter: brightness(2.23);
}
`