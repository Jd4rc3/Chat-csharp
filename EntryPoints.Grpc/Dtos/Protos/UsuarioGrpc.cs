// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/Usuario.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981
#region Designer generated code

using grpc = global::Grpc.Core;

namespace EntryPoints.Grpc.Dtos.Protos {
  public static partial class UsuarioService
  {
    static readonly string __ServiceName = "usuario.UsuarioService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::EntryPoints.Grpc.Dtos.Protos.SignUpRequest> __Marshaller_usuario_SignUpRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::EntryPoints.Grpc.Dtos.Protos.SignUpRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::EntryPoints.Grpc.Dtos.Protos.Response> __Marshaller_usuario_Response = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::EntryPoints.Grpc.Dtos.Protos.Response.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::EntryPoints.Grpc.Dtos.Protos.SignInRequest> __Marshaller_usuario_SignInRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::EntryPoints.Grpc.Dtos.Protos.SignInRequest.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::EntryPoints.Grpc.Dtos.Protos.SignUpRequest, global::EntryPoints.Grpc.Dtos.Protos.Response> __Method_SignUp = new grpc::Method<global::EntryPoints.Grpc.Dtos.Protos.SignUpRequest, global::EntryPoints.Grpc.Dtos.Protos.Response>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SignUp",
        __Marshaller_usuario_SignUpRequest,
        __Marshaller_usuario_Response);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::EntryPoints.Grpc.Dtos.Protos.SignInRequest, global::EntryPoints.Grpc.Dtos.Protos.Response> __Method_SignIn = new grpc::Method<global::EntryPoints.Grpc.Dtos.Protos.SignInRequest, global::EntryPoints.Grpc.Dtos.Protos.Response>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SignIn",
        __Marshaller_usuario_SignInRequest,
        __Marshaller_usuario_Response);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::EntryPoints.Grpc.Dtos.Protos.UsuarioReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of UsuarioService</summary>
    [grpc::BindServiceMethod(typeof(UsuarioService), "BindService")]
    public abstract partial class UsuarioServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::EntryPoints.Grpc.Dtos.Protos.Response> SignUp(global::EntryPoints.Grpc.Dtos.Protos.SignUpRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::EntryPoints.Grpc.Dtos.Protos.Response> SignIn(global::EntryPoints.Grpc.Dtos.Protos.SignInRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for UsuarioService</summary>
    public partial class UsuarioServiceClient : grpc::ClientBase<UsuarioServiceClient>
    {
      /// <summary>Creates a new client for UsuarioService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public UsuarioServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for UsuarioService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public UsuarioServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected UsuarioServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected UsuarioServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::EntryPoints.Grpc.Dtos.Protos.Response SignUp(global::EntryPoints.Grpc.Dtos.Protos.SignUpRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SignUp(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::EntryPoints.Grpc.Dtos.Protos.Response SignUp(global::EntryPoints.Grpc.Dtos.Protos.SignUpRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SignUp, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::EntryPoints.Grpc.Dtos.Protos.Response> SignUpAsync(global::EntryPoints.Grpc.Dtos.Protos.SignUpRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SignUpAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::EntryPoints.Grpc.Dtos.Protos.Response> SignUpAsync(global::EntryPoints.Grpc.Dtos.Protos.SignUpRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SignUp, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::EntryPoints.Grpc.Dtos.Protos.Response SignIn(global::EntryPoints.Grpc.Dtos.Protos.SignInRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SignIn(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::EntryPoints.Grpc.Dtos.Protos.Response SignIn(global::EntryPoints.Grpc.Dtos.Protos.SignInRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SignIn, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::EntryPoints.Grpc.Dtos.Protos.Response> SignInAsync(global::EntryPoints.Grpc.Dtos.Protos.SignInRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SignInAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::EntryPoints.Grpc.Dtos.Protos.Response> SignInAsync(global::EntryPoints.Grpc.Dtos.Protos.SignInRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SignIn, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override UsuarioServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new UsuarioServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(UsuarioServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SignUp, serviceImpl.SignUp)
          .AddMethod(__Method_SignIn, serviceImpl.SignIn).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, UsuarioServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SignUp, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::EntryPoints.Grpc.Dtos.Protos.SignUpRequest, global::EntryPoints.Grpc.Dtos.Protos.Response>(serviceImpl.SignUp));
      serviceBinder.AddMethod(__Method_SignIn, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::EntryPoints.Grpc.Dtos.Protos.SignInRequest, global::EntryPoints.Grpc.Dtos.Protos.Response>(serviceImpl.SignIn));
    }

  }
}
#endregion
