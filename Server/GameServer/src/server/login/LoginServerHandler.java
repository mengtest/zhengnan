package server.login;

import io.netty.channel.Channel;
import io.netty.channel.ChannelHandlerContext;
import io.netty.channel.SimpleChannelInboundHandler;
import io.netty.channel.group.ChannelGroup;
import io.netty.channel.group.DefaultChannelGroup;
import io.netty.util.concurrent.GlobalEventExecutor;
import org.apache.log4j.Logger;
import server.common.Monitor;

/**
 * @ClassName: GateServerHandler
 * @Description: TODO
 * @Author: zhengnan
 * @Date: 2018/6/1 21:05
 */
public class LoginServerHandler extends SimpleChannelInboundHandler<Monitor>
{
    final static Logger logger = Logger.getLogger(LoginServerHandler.class.getName());

    protected LoginMonitor monitor;

    public LoginServerHandler(LoginMonitor monitor)
    {
        this.monitor = monitor;
    }
    @Override
    public void handlerAdded(ChannelHandlerContext ctx) throws Exception
    {  // (2)
        Channel incoming = ctx.channel();

        // Broadcast a message to multiple Channels
        // channels.writeAndFlush("[SERVER] - " + incoming.remoteAddress() + " 加入\n");

        monitor.getChannelGroup().add(ctx.channel());
    }

    @Override
    protected void channelRead0(ChannelHandlerContext ctx, Monitor monitor) throws Exception
    {
        Channel incoming = ctx.channel();
        logger.info("Channel:" + incoming.id());
    }

    @Override
    public void channelActive(ChannelHandlerContext ctx) throws Exception
    { // (5)
        Channel incoming = ctx.channel();
        logger.info("Client ip:" + incoming.remoteAddress() + " is online");
    }

    @Override
    public void channelInactive(ChannelHandlerContext ctx) throws Exception
    { // (6)
        Channel incoming = ctx.channel();
        logger.info("Client ip:" + incoming.remoteAddress() + " is offline");
        monitor.getChannelGroup().remove(ctx.channel());
    }

    @Override
    public void exceptionCaught(ChannelHandlerContext ctx, Throwable cause)
    {
        Channel incoming = ctx.channel();
        logger.error("Client ip:" + incoming.remoteAddress() + " is exception");
        // 当出现异常就关闭连接
        cause.printStackTrace();
        ctx.close();
    }
}