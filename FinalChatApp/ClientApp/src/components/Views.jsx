import React from 'react'
import { Routes, Route } from 'react-router'


const Views = () => {
  return (
                
              <Routes>
                <Route
                  exact
                  path={"/chat-app"}
                  element={LoginForm}
                />
              </Routes>
            
  )
}

export default Views
