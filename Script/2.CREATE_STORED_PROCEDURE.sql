use BDTEST
GO

CREATE PROCEDURE USP_Listar_Entidad --'Archivo'    
(    
@cDescripcion VARCHAR(150)=''    
)    
AS    
BEGIN    
    
SELECT     
CodigoEntidad=nId,    
DescripcionEntidad=cDescripcion,    
FechaRegistro=CONVERT(VARCHAR(10), dFechaRegistro, 105),    
EstadoEntidad= 'Activo'  FROM EntidadGubernamental    
where bEstado=1 AND cDescripcion like '%'+ @cDescripcion +'%'    
END    

GO

CREATE PROCEDURE USP_Create_Entidad   
(  
@cDescripcion VARCHAR(150),  
@nIdEntidad INT OUTPUT   
)  
AS  
BEGIN  
  
DECLARE @p_IdResultado int  
  INSERT INTO EntidadGubernamental (cDescripcion,dFechaRegistro,bEstado) VALUES (@cDescripcion,GETDATE(),1)  
  SET @nIdEntidad = SCOPE_IDENTITY()  
END  

GO

CREATE PROCEDURE USP_Update_Entidad   
(  
@nId INT,  
@cDescripcion VARCHAR(150),  
@nIdEntidad INT OUTPUT   
)  
AS  
BEGIN  
 UPDATE EntidadGubernamental   
  SET cDescripcion =@cDescripcion,  
  dFechaActualizacion=GETDATE()  
  where nId=@nId  
 SET @nIdEntidad = @nId   
END

GO

CREATE PROCEDURE USP_Delete_Entidad   
(  
@nId INT,  
@nIdEntidad INT OUTPUT   
)  
AS  
BEGIN  
 UPDATE EntidadGubernamental   
  SET bEstado=0,  
  dFechaActualizacion=GETDATE()  
  where nId=@nId  
 SET @nIdEntidad = @nId   
END  

GO
 